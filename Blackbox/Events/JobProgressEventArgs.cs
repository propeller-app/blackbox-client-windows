using System;

namespace Blackbox.Events
{
    public class JobProgressEventArgs : EventArgs
    {
        public JobProgressEventArgs(EventArgs e, int jobPercent)
        {
            Event = e;
            JobPercent = jobPercent;
        }

        public EventArgs Event { get; }
        public int JobPercent { get; }
    }
}
