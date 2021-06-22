using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redhvid
{
    public class JobData
    {
        public JobData(string customerFirstName, string customerLastName, string customerEmail)
        {
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CustomerEmail = customerEmail;
        }

        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
    }
}
