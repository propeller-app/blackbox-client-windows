using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Redhvid
{
    public static class Utils
    {
        public static String GetGRPCUrl()
        {
            String proto = Properties.Settings.Default.GrpcSSL ? "https" : "http";
            String host = Properties.Settings.Default.GrpcHost;
            uint port = Properties.Settings.Default.GrpcPort;
            return $"{proto}://{host}:{port}";
        }

        public static DirectoryInfo GetTempJobDirectory(Job job)
        {
            return Directory.CreateDirectory(Path.Combine(
                Path.GetTempPath(),
                "redh",
                $"job{job.JobId}"
            ));
        }

        public static Point GetTrayWindowLocation(Form form)
        {
            Rectangle workingArea = Screen.GetWorkingArea(form);
            return new Point(workingArea.Width - form.Width,  workingArea.Height - form.Height);
        }
    }
}
