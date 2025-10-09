using Blackbox.Client.Events;
using ByteSizeLib;
using Microsoft.Toolkit.Uwp.Notifications;
using SpeedTestSharp.Client;
using SpeedTestSharp.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xabe.FFmpeg;

namespace Blackbox
{
    public static class Utils
    {
        public static String GetGrpcUrl()
        {
            String proto = Properties.Settings.Default.GrpcSSL ? "https" : "http";
            String host = Properties.Settings.Default.GrpcHost;
            uint port = Properties.Settings.Default.GrpcPort;
            return $"{proto}://{host}:{port}";
        }

        public static DirectoryInfo GetTempJobDirectory()
        {
            return Directory.CreateDirectory(Path.Combine(
                Path.GetTempPath(),
                Properties.Strings.ApplicationShortName,
                Guid.NewGuid().ToString()
            ));
        }

        public static Point GetTrayWindowLocation(Form form)
        {
            Rectangle workingArea = Screen.GetWorkingArea(form);
            return new Point(workingArea.Width - form.Width, workingArea.Height - form.Height);
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

        async public static Task<(TimeSpan Duration, long FileSize)> BenchmarkFlavor(string flavor, string testVideoPath)
        {
            Console.WriteLine($"Benchmarking: {flavor} with {testVideoPath}.");
            string outputPath = Path.Combine(Path.GetTempPath(), $"benchmark_{flavor}_{Guid.NewGuid()}.mp4");

            long fileSize = 0;
            var stopwatch = Stopwatch.StartNew();

            try
            {
                string ffmpegFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg");
                FFmpeg.SetExecutablesPath(ffmpegFolder);
                var conversion = await FFmpeg.Conversions.FromSnippet.Convert(testVideoPath, outputPath);
                conversion.AddParameter(flavor);

                await conversion.Start();
            }
            finally
            {
                stopwatch.Stop();
                // Clean up the temporary file
                if (File.Exists(outputPath))
                    fileSize = new FileInfo(outputPath).Length;
                    File.Delete(outputPath);
            }
            return (stopwatch.Elapsed, fileSize);
        }

        public static async Task<double> GetUploadSpeedMbpsAsync()
        {
            ISpeedTestClient speedTestClient = new SpeedTestClient();
            var result = await speedTestClient.TestSpeedAsync(SpeedUnit.Mbps, testDownload: false, testLatency: false);
            return result.UploadSpeed;
        }

        public static void CloseOpenProcesses()
        {
            Process myself = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(myself.ProcessName);
            if (processes.Length > 1)
            {
                bool userNotified = false;
                foreach (Process p in processes)
                {
                    if (p.MainModule.FileName == Application.ExecutablePath && p.Id != myself.Id)
                    {
                        if (!userNotified)
                        {
                            DialogResult res = MessageBox.Show(
                                Properties.Strings.WarnDuplicateProcessDescription,
                                Properties.Strings.WarnDuplicateProcessTitle,
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question);
                            if (res == DialogResult.Cancel)
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
        }

        public static string GetJobEventMessage(JobProgressEventArgs e)
        {
            if (e.Event is CloneProgressEventArgs ce)
                return string.Format(Properties.Strings.JobStatusCloning, ce.FileNum + 1, ce.FileTotal, ByteSize.FromBytes(ce.BytesProcessed), ByteSize.FromBytes(ce.BytesTotal));
            else if (e.Event is CloneCompleteEventArgs)
                return Properties.Strings.JobStatusCloneComplete;
            else if (e.Event is TranscodeProgressEventArgs te)
                return string.Format(Properties.Strings.JobStatusTranscoding, te.ProcessedLength, te.TotalLength);
            else if (e.Event is TranscodeCompleteEventArgs)
                return Properties.Strings.JobStatusTranscodeComplete;
            else if (e.Event is UploadProgressEventArgs ue)
                return string.Format(Properties.Strings.JobStatusUploading, ByteSize.FromBytes(ue.BytesProcessed), ByteSize.FromBytes(ue.BytesTotal));
            else if (e.Event is UploadCompleteEventArgs)
                return Properties.Strings.JobStatusUploadComplete;
            return Properties.Strings.JobStatusReady;
        }

        public static void WriteFailedJobLog(Exception reason)
        {
            string logFileDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                String.Format(Properties.Strings.LogDirectoryName, Properties.Strings.ApplicationLongName));
            Directory.CreateDirectory(logFileDirectory);
            string logFilePath = Path.Combine(
                logFileDirectory,
                String.Format(Properties.Strings.LogFileName, DateTime.Now));
            File.WriteAllText(logFilePath, reason.ToString());
        }

        public class RightBottomAlignedForm : Form
        {
            public void AlignForm()
            {
                Rectangle workingArea = Screen.GetWorkingArea(this);
                Location = new Point(
                    workingArea.Width - Width,
                    workingArea.Height - Height
                );
            }
        }
    }
}
