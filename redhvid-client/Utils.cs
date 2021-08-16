using System;
using System.Collections.Generic;
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

        public static List<string> GetAllAccessibleFiles(string path, string searchPattern, List<string> alreadyFound = null)
        {
            if (alreadyFound == null)
                alreadyFound = new List<string>();
            DirectoryInfo di = new(path);
            var dirs = di.EnumerateDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                if (!((dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                {
                    alreadyFound = GetAllAccessibleFiles(dir.FullName, searchPattern, alreadyFound);
                }
            }

            var files = Directory.GetFiles(path, searchPattern);
            foreach (string s in files)
            {
                alreadyFound.Add(s);
            }

            return alreadyFound;
        }
    }
}
