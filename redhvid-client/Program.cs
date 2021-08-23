using Grpc.Net.Client;
using Redhvid.Enums;
using Redhvid.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Usb.Events;

namespace Redhvid
{
    public static class Program
    {
        private static readonly JobProgressForm jobProgressForm = new();
        private static readonly IUsbEventWatcher usbEventWatcher = new UsbEventWatcher();

        private static readonly Queue<Job> jobQueue = new();
        private static Job currentJob;

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Process myself = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(myself.ProcessName);
            if (processes.Length > 1)
            {
                bool userNotified = false;
                foreach(Process p in processes)
                {
                    if(p.MainModule.FileName == Application.ExecutablePath && p.Id != myself.Id)
                    {
                        if(!userNotified)
                        {
                            DialogResult res = MessageBox.Show(
                                "There is already an instance of the application running. Proceed and kill existing processes?", 
                                "Kill existing processes", 
                                MessageBoxButtons.OKCancel, 
                                MessageBoxIcon.Question);
                            if(res == DialogResult.Cancel)
                            {
                                Application.Exit();
                                return;
                            }
                            userNotified = true;
                        }
                        p.Kill();
                    }
                }
            }

            InitApplication();
            Application.Run(jobProgressForm);
        }

        public static void ShowJobProgress()
        {
            jobProgressForm.Show();
        }

        public static void HideJobProgress()
        {
            jobProgressForm.Hide();
        }

        private static void InitApplication()
        {
            usbEventWatcher.UsbDeviceAdded += UsbDeviceConnected;
        }

        private static void UsbDeviceConnected(object sender, UsbDevice device)
        {
            if (Properties.Settings.Default.Devices != null &&
                Properties.Settings.Default.Devices.Contains(device.DeviceSystemPath))
            {
                jobProgressForm.Invoke(new Action(() =>
                {
                    Process jobPreviewProcess = Process.Start("explorer.exe", device.MountedDirectoryPath);

                    StartJobForm startJobForm = new();
                    startJobForm.beginJobButton.Click += (object sender, EventArgs e) =>
                    {
                        GrpcChannel channel = GrpcChannel.ForAddress(Utils.GetGRPCUrl());

                        Job job = new();
                        job.SetDevicePath(device.MountedDirectoryPath);
                        job.SetSpoolClient(new(channel));
                        jobProgressForm.SetJob(job);
                        jobQueue.Enqueue(job);

                        ProcessJobQueue();
                        startJobForm.Close();
                    };

                    startJobForm.cancelButton.Click += (object sender, EventArgs e) =>
                    {
                        startJobForm.Close();
                    };
                    jobProgressForm.Hide();
                    startJobForm.Show();
                }));
            }
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

                SetThreadExecutionState(EXECUTION_STATE.ES_AWAYMODE_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
                currentJob.JobComplete += (object sender, JobCompleteEventArgs e) =>
                    SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);

                jobProgressForm.Invoke(new Action(() =>
                {
                    JobDataForm jobDataForm = new(currentJob);
                    jobDataForm.Show();
                }));
            } else
            {
                MessageBox.Show(
                    "Please wait for the current job to complete before starting another.", 
                    "Concurrent jobs not supported", 
                    MessageBoxButtons.OK);
            }
        }
    }
}
