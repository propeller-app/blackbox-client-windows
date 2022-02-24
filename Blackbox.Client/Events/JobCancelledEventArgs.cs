using System;

namespace Blackbox.Client.Events
{
    public class JobCancelledEventArgs : EventArgs
    {
        public JobCancelledEventArgs()
        {
            Reason = new Exception("Cancelled by request");
        }

        public JobCancelledEventArgs(Exception reason)
        {
            Reason = reason;
        }

        public Exception Reason { get; set; }
    }
}
