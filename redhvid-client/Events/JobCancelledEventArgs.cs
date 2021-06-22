using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redhvid.Events
{
    public class JobCancelledEventArgs : EventArgs
    {
        public JobCancelledEventArgs(Exception reason)
        {
            Reason = reason;
        }

        public Exception Reason { get; set; }
    }
}
