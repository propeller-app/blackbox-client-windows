using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redhvid.Events
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
