using System;
using System.IO;

namespace Blackbox.Client.Events
{
    public class CloneCompleteEventArgs : EventArgs
    {
        public CloneCompleteEventArgs(int fileTotal, DirectoryInfo outputDir)
        {
            FileTotal = fileTotal;
            OutputDir = outputDir;
        }

        public int FileTotal { get; set; }
        public DirectoryInfo OutputDir { get; set; }
    }
}
