using System;
using System.Windows.Forms;
using Grpc.Net.Client;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Redhvid
{
    public class RedhApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public RedhApplicationContext()
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add(new ToolStripMenuItem("Create New Job", null, OpenNewJobWindow));
            menuStrip.Items.Add(new ToolStripMenuItem("View Job History", null, OpenJobHistoryWindow));
            menuStrip.Items.Add(new ToolStripMenuItem("Settings", null, OpenSettingsWindow));
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(new ToolStripMenuItem("Exit", null, Exit));

            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.AppIcon,
                ContextMenuStrip = menuStrip,
                Text = "Redhill Flight Video",
                Visible = true
            };

            using var channel = GrpcChannel.ForAddress("http://192.168.1.4:50051");
            var client = new FlightVideoDistributor.FlightVideoDistributorClient(channel);
            var reply = client.Echo(new FlightVideoMessage { Message = "Hello world" });
            Console.WriteLine("Echo response: " + reply.Message);

            new ToastContentBuilder()
                .AddText("Connected to gRPC")
                .AddText("Successfully established a connection to gRPC server!").Show();

        }

        private void OpenNewJobWindow(object sender, EventArgs e)
        {
            NewJobForm nj = new NewJobForm();
            nj.Show();
        }

        private void OpenJobHistoryWindow(object sender, EventArgs e)
        {
            JobHistoryForm jh = new JobHistoryForm();
            jh.Show();
        }

        private void OpenSettingsWindow(object sender, EventArgs e)
        {
            SettingsForm s = new SettingsForm();
            s.Show();
        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
