using Blackbox.Client;
using Blackbox.Client.Enums;
using Blackbox.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using MediaDevices;

namespace Blackbox
{
    public static class Program
    {
        private static readonly JobProgressForm jobProgressForm = new();
        //private static ManagementEventWatcher volumeWatcher;
        private static ManagementEventWatcher pnpWatcher;

        private static readonly Queue<Job> jobQueue = new();
        private static Job currentJob;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Utils.CloseOpenProcesses();

            jobProgressForm.trayIcon.Icon = Properties.Resources.AppIconReady;
            jobProgressForm.trayIcon.Text = String.Format(
                Properties.Strings.TaskTrayTitle,
                Properties.Resources.AppName,
                Properties.Strings.TaskTrayReady);

            InitApplication();

            if (args.Length > 0)
            {
                List<string> selectedFiles = new(args);
                CreateNewJobFromFiles(selectedFiles);
                Application.Run(jobProgressForm);
            }
            else
            {
                Application.Run(jobProgressForm);
            }
        }

        private static void InitApplication()
        {
            // Watch for *any* new PnP devices (e.g., GoPro in MTP mode)
            string pnpQuery = "SELECT * FROM __InstanceCreationEvent " +
                              "WITHIN 2 " +
                              "WHERE TargetInstance ISA 'Win32_PnPEntity'";
            pnpWatcher = new ManagementEventWatcher(new WqlEventQuery(pnpQuery));
            pnpWatcher.EventArrived += PnpDeviceConnected;
            pnpWatcher.Start();
        }


        private static bool DeviceMatches(string pnpId, string deviceId)
        {
            if (string.IsNullOrEmpty(pnpId) || string.IsNullOrEmpty(deviceId))
                return false;

            string normPnp = NormalizeId(pnpId);
            string normDevice = NormalizeId(deviceId);

            return normDevice.Contains(normPnp) || normPnp.Contains(normDevice);
        }

        private static string NormalizeId(string id)
        {
            if (string.IsNullOrEmpty(id))
                return string.Empty;

            string norm = id
                .Replace("\\", "")
                .Replace("#", "")
                .Replace("?", "")
                .ToLowerInvariant();

            // Strip off any GUID part like {6ac27878-...}
            int guidIndex = norm.IndexOf('{');
            if (guidIndex >= 0)
                norm = norm.Substring(0, guidIndex);

            // Strip off any &mi_0X section
            int miIndex = norm.IndexOf("&mi_0", StringComparison.OrdinalIgnoreCase);
            if (miIndex >= 0)
                norm = norm.Substring(0, miIndex);

            return norm;
        }


        public class DeviceAccessResult
        {
            public string DriveLetter { get; set; }    // e.g. "E:\"
            public MediaDevice MtpDevice { get; set; } // For MTP
        }


        public static string GetDriveLetterFromPnP(string pnpId)
        {
            if (string.IsNullOrEmpty(pnpId)) return null;

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
            {
                foreach (ManagementObject drive in searcher.Get())
                {
                    string drivePnP = drive["PNPDeviceID"]?.ToString();
                    if (!string.IsNullOrEmpty(drivePnP) &&
                        (pnpId.Contains(drivePnP, StringComparison.OrdinalIgnoreCase) ||
                         drivePnP.Contains(pnpId, StringComparison.OrdinalIgnoreCase)))
                    {
                        foreach (ManagementObject partition in drive.GetRelated("Win32_DiskPartition"))
                        {
                            foreach (ManagementObject logicalDisk in partition.GetRelated("Win32_LogicalDisk"))
                            {
                                return logicalDisk["DeviceID"]?.ToString() + "\\";
                            }
                        }
                    }
                }
            }
            return null;
        }


        public static DeviceAccessResult GetDeviceAccess(string pnpId)
        {
            if (string.IsNullOrEmpty(pnpId))
                return null;

            string driveLetter = GetDriveLetterFromPnP(pnpId);

            if (!string.IsNullOrEmpty(driveLetter))
            {
                return new DeviceAccessResult { DriveLetter = driveLetter };

            }

            // Try MTP (Portable Devices)
            var devices = MediaDevice.GetDevices();
            foreach (var dev in devices)
            {
                if (DeviceMatches(pnpId, dev.DeviceId))
                {
                    return new DeviceAccessResult { MtpDevice = dev };
                }
            }

            return null; // No match found
        }

        // Store last job-start times per device
        private static DateTime _lastJob = DateTime.MinValue;
        private static readonly object _jobLock = new object();
        private const int JobCooldownMs = 1000; // 1 seconds


        private static void PnpDeviceConnected(object sender, EventArrivedEventArgs e)
        {
            var instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            string name = instance["Name"]?.ToString() ?? "(Unknown)";
            string pnpId = instance["PNPDeviceID"]?.ToString();

            var result = GetDeviceAccess(pnpId);

            if (result != null)
            {
                if (result.DriveLetter != null)
                {
                    if (IsDeviceInSettings(pnpId) && CanStartJob())
                    {
                        MarkJobStarted();
                        jobProgressForm.Invoke(new Action<string, MediaDevice>(CreateNewJob), result.DriveLetter, null);
                    }
                }
                else if (result.MtpDevice != null)
                {
                    if (IsDeviceInSettings(pnpId) && CanStartJob())
                    {
                        MarkJobStarted();
                        jobProgressForm.Invoke(new Action<string, MediaDevice>(CreateNewJob), null, result.MtpDevice);
                    }
                }
            }
        }

        private static bool CanStartJob()
        {
            lock (_jobLock)
            {
                if ((DateTime.Now - _lastJob).TotalMilliseconds < JobCooldownMs)
                {
                    return false;
                }
                return true;
            }
        }

        private static void MarkJobStarted()
        {
            lock (_jobLock)
            {
                _lastJob = DateTime.Now;
            }
        }


        public static bool IsDeviceInSettings(string pnpId)
        {
            foreach (Device device in Properties.Settings.Default.Devices)
            {
                if (DeviceMatches(pnpId, device.Id))
                    return true;
            }
            return false;
        }


        private static void CreateNewJob(string sourceDirectory, MediaDevice mtp)
        {
            if (Properties.Settings.Default.Explorer)
            {
                Process jobPreviewProcess = Process.Start("explorer.exe", sourceDirectory);
            }

            StartJobForm startJobForm = new();
            startJobForm.BringToFront();

            if (mtp is null)
            {
                startJobForm.beginJobButton.Click += (object sender, EventArgs e) =>
                {
                    Job job = new();
                    job
                        .SetSourceFiles(Utils.GetAllAccessibleFiles(sourceDirectory, "*.mp4"))
                        .SetMtpDevice(null)
                        .SetGrpcUrl(Utils.GetGrpcUrl())
                        .SetTempDirectory(Utils.GetTempJobDirectory())
                        .SetFfmpegFlags(Properties.Settings.Default.FFmpegFlags)
                        .SetJobExpiryDays(Properties.Settings.Default.JobExpiryDays);

                    jobQueue.Enqueue(job);

                    ProcessJobQueue();
                    startJobForm.Close();
                };

                startJobForm.cancelButton.Click += (object sender, EventArgs e) =>
                {
                    startJobForm.Close();
                };

                jobProgressForm.Hide();
                jobProgressForm.trayIcon.Icon = Properties.Resources.AppIconReady;
                startJobForm.Show();
            }
            else
            {
                startJobForm.beginJobButton.Click += (object sender, EventArgs e) =>
                {
                    Job job = new();
                    job
                        .SetMtpDevice(mtp)
                        .SetGrpcUrl(Utils.GetGrpcUrl())
                        .SetTempDirectory(Utils.GetTempJobDirectory())
                        .SetFfmpegFlags(Properties.Settings.Default.FFmpegFlags)
                        .SetJobExpiryDays(Properties.Settings.Default.JobExpiryDays);

                    jobQueue.Enqueue(job);

                    ProcessJobQueue();
                    startJobForm.Close();
                };

                startJobForm.cancelButton.Click += (object sender, EventArgs e) =>
                {
                    startJobForm.Close();
                };

                jobProgressForm.Hide();
                jobProgressForm.trayIcon.Icon = Properties.Resources.AppIconReady;
                startJobForm.Show();
            }
            
        }

        private static void CreateNewJobFromFiles(List<string> selectedFiles)
        {
            Job job = new();
            job
                .SetSourceFiles(selectedFiles)
                .SetGrpcUrl(Utils.GetGrpcUrl())
                .SetTempDirectory(Utils.GetTempJobDirectory())
                .SetFfmpegFlags(Properties.Settings.Default.FFmpegFlags)
                .SetJobExpiryDays(Properties.Settings.Default.JobExpiryDays);

            jobQueue.Enqueue(job);

            ProcessJobQueue();
        }

        private static void ProcessJobQueue()
        {
            if (currentJob != null && currentJob.Status == JobStatus.Complete)
            {
                currentJob = null;
            }

            if (currentJob == null)
            {
                currentJob = jobQueue.Dequeue();
                currentJob.Start();

                JobWatcher jobWatcher = new(currentJob);
                JobDataForm jobDataForm = new();

                ManualResetEvent progressSignalEvent = new(false);

                jobProgressForm.trayIcon.Icon = Properties.Resources.AppIconBusy;
                jobProgressForm.UpdateNotification(Properties.Strings.NotificationMediaUnsafe);

                SleepNativeMethods.PreventSleep();
                currentJob.JobComplete += (object sender, JobCompleteEventArgs e) =>
                {
                    jobProgressForm.UpdateProgress(0);
                    jobProgressForm.UpdateStatus(Properties.Strings.JobStatusReady);
                    jobProgressForm.Hide();
                    jobProgressForm.trayIcon.ShowBalloonTip(0,
                        Properties.Strings.BalloonJobCompleteTitle,
                        Properties.Strings.BalloonJobCompleteDescription,
                        ToolTipIcon.Info);
                    jobProgressForm.trayIcon.Icon = Properties.Resources.AppIconReady;
                    jobProgressForm.trayIcon.Text = String.Format(
                        Properties.Strings.TaskTrayTitle,
                        Properties.Resources.AppName,
                        Properties.Strings.TaskTrayReady);
                    jobProgressForm.UpdateNotification(String.Empty);
                    SleepNativeMethods.AllowSleep();
                };

                currentJob.JobCancelled += (object sender, JobCancelledEventArgs e) =>
                {
                    jobProgressForm.UpdateProgress(0);
                    jobProgressForm.UpdateStatus(Properties.Strings.JobStatusReady);
                    jobProgressForm.Hide();
                    jobProgressForm.trayIcon.ShowBalloonTip(0,
                        Properties.Strings.BalloonJobCancelledTitle,
                        Properties.Strings.BalloonJobCancelledDescription,
                        ToolTipIcon.Error);
                    jobProgressForm.trayIcon.Icon = Properties.Resources.AppIconError;
                    jobProgressForm.trayIcon.Text = String.Format(
                        Properties.Strings.TaskTrayTitle,
                        Properties.Resources.AppName,
                        Properties.Strings.TaskTrayCancelled);
                    jobProgressForm.UpdateNotification(String.Empty);
                    SleepNativeMethods.AllowSleep();
                    currentJob = null;
                    jobDataForm.Close();

                    Utils.WriteFailedJobLog(e.Reason);
                };

                void updateJobDataFormProgress(object sender, JobProgressEventArgs e)
                {
                    progressSignalEvent.Reset();
                    jobDataForm.BeginInvoke(new Action<int>(jobDataForm.UpdateProgress), e.JobPercent);
                    jobDataForm.BeginInvoke(new Action<string>(jobDataForm.UpdateStatus), Utils.GetJobEventMessage(e));
                    progressSignalEvent.Set();
                };

                void updateJobProgressFormProgress(object sender, JobProgressEventArgs e)
                {
                    if (e.Event is CloneCompleteEventArgs)
                    {
                        jobProgressForm.UpdateNotification(Properties.Strings.NotificationMediaSafe);
                    }
                    jobProgressForm.UpdateProgress(e.JobPercent);
                    jobProgressForm.UpdateStatus(Utils.GetJobEventMessage(e));
                    jobProgressForm.trayIcon.Text = String.Format(
                        Properties.Strings.TaskTrayTitle,
                        Properties.Resources.AppName,
                        String.Format(Properties.Strings.TaskTrayBusy, e.JobPercent));
                }

                jobWatcher.JobProgress += updateJobDataFormProgress;
                jobWatcher.JobProgress += updateJobProgressFormProgress;

                jobDataForm.uploadButton.Click += (object sender, EventArgs e) =>
                {
                    currentJob.SetJobData(new JobData(
                        jobDataForm.firstNameTextBox.Text,
                        jobDataForm.lastNameTextBox.Text,
                        jobDataForm.emailTextBox.Text));
                    jobWatcher.JobProgress -= updateJobDataFormProgress;

                    progressSignalEvent.WaitOne();
                    jobDataForm.Close();
                    jobProgressForm.Show();
                    jobProgressForm.WindowState = FormWindowState.Normal;
                    jobProgressForm.BringToFront();
                    jobProgressForm.Activate();
                };

                jobDataForm.cancelButton.Click += (object sender, EventArgs e) =>
                {
                    jobWatcher.JobProgress -= updateJobDataFormProgress;
                    currentJob.Cancel();
                };

                jobDataForm.Show();
            }
            else
            {
                MessageBox.Show(
                    Properties.Strings.WarnConcurrentDescription,
                    Properties.Strings.WarnConcurrentTitle,
                    MessageBoxButtons.OK);
            }
        }
    }
}
