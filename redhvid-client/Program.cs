using Grpc.Net.Client;
using Redhvid.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
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

        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitApplication();
            Application.Run(jobProgressForm);
        }

        public static void ShowJobProgress()
        {
            jobProgressForm.Opacity = 100;
            jobProgressForm.Focus();
        }

        public static void HideJobProgress()
        {
            jobProgressForm.Opacity = 0;
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
                GrpcChannel channel = GrpcChannel.ForAddress(Utils.GetGRPCUrl());

                Job job = new();
                job.SetDevicePath(device.MountedDirectoryPath);
                job.SetSpoolClient(new(channel));
                jobQueue.Enqueue(job);

                ProcessJobQueue();
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

                jobProgressForm.Invoke(new Action(() =>
                {
                    JobDataForm jobDataForm = new(currentJob);
                    jobDataForm.Show();
                }));
            }
        }
    }
}
