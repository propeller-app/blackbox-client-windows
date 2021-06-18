using System;

namespace Redhvid.Events
{
    public class CloneProgressEventArgs : EventArgs
    {
        public CloneProgressEventArgs(int fileNum, string fileName, int fileTotal, decimal percent)
        {
            FileNum = fileNum;
            FileName = fileName;
            FileTotal = fileTotal;
            Percent = percent;
        }

        public int FileNum { get; set; }
        public string FileName { get; set; }
        public int FileTotal { get; set; }
        public decimal Percent { get; set; }
    }
}
