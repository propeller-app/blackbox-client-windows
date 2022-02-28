using System;

namespace Blackbox.Client.Events
{
    public class TranscodeProgressEventArgs : EventArgs
    {
        public TranscodeProgressEventArgs(TimeSpan processedLength, TimeSpan totalLength)
        {
            ProcessedLength = processedLength;
            TotalLength = totalLength;
        }

        public TimeSpan ProcessedLength { get; }
        public TimeSpan TotalLength { get; }
        public int Percent => (int)Math.Round(((double)ProcessedLength.TotalSeconds / TotalLength.TotalSeconds) * 100);
    }
}
