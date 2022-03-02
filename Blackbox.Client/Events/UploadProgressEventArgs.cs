using System;

namespace Blackbox.Client.Events
{
    public class UploadProgressEventArgs : EventArgs
    {
        public UploadProgressEventArgs(long bytesTotal, long bytesProcessed)
        {
            BytesTotal = bytesTotal;
            BytesProcessed = bytesProcessed;
        }

        public long BytesTotal { get; private set; }
        public long BytesProcessed { get; private set; }
        public int Percent => (int)Math.Round(((double) BytesProcessed / BytesTotal) * 100);
    }
}
