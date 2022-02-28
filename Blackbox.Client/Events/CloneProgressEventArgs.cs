using System;

namespace Blackbox.Client.Events
{
    public class CloneProgressEventArgs : EventArgs
    {
        public CloneProgressEventArgs(string fileName, int fileNum, int fileTotal, long bytesProcessed, long bytesTotal)
        {
            FileName = fileName;
            FileNum = fileNum;
            FileTotal = fileTotal;
            BytesProcessed = bytesProcessed;
            BytesTotal = bytesTotal;
        }

        public int FileNum { get; }
        public string FileName { get; }
        public int FileTotal { get; }
        public long BytesProcessed { get; }
        public long BytesTotal { get; }
        public int FilePercent => (int)Math.Round(((double)BytesProcessed / BytesTotal) * 100);
        public int Percent => (int)Math.Round((double)100 * (((1.0 / FileTotal) * FileNum) + ((FilePercent / 100.0) * (1.0 / FileTotal))));
    }
}
