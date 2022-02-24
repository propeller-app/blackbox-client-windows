using Blackbox.Client;
using Blackbox.Client.Enums;
using Blackbox.Client.Events;
using Blackbox.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Usb.Events;

namespace Blackbox
{
    public static class Program
    {
        private static readonly JobProgressForm jobProgressForm = new();
        private static readonly IUsbEventWatcher usbEventWatcher = new UsbEventWatcher();

        private static readonly Queue<Job> jobQueue = new();
        private static Job currentJob;

        [STAThread]
        public static void Main()
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
            Application.Run(jobProgressForm);
        }

        private static void InitApplication()
        {
            usbEventWatcher.UsbDeviceAdded += UsbDeviceConnected;
        }

        private static void UsbDeviceConnected(object sender, UsbDevice device)
        {
            if (Properties.Settings.Default.Devices != null &&
                Properties.Settings.Default.Devices.Contains(new Device(device.DeviceSystemPath, device.DeviceName)))
            {
                jobProgressForm.Invoke(new Action<string>(CreateNewJob), device.MountedDirectoryPath);
            }
        }

        private static void CreateNewJob(string sourceDirectory)
        {
            if (Properties.Settings.Default.Explorer)
            {
                Process jobPreviewProcess = Process.Start("explorer.exe", sourceDirectory);
            }

            StartJobForm startJobForm = new();

            startJobForm.beginJobButton.Click += (object sender, EventArgs e) =>
            {
                Job job = new();
                job
                    .SetSourceFiles(Utils.GetAllAccessibleFiles(sourceDirectory, "*.mp4"))
                    .SetGrpcUrl(Utils.GetGrpcUrl())
                    .SetTempDirectory(Utils.GetTempJobDirectory())
                    .SetFfmpegFlags(Properties.Settings.Default.FFmpegFlags)
                    .SetJobExpiryDays(Properties.Settings.Default.JobExpiryDays)
                    .SetMaxMessageSize(Properties.Settings.Default.MaxMessageSize);

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
