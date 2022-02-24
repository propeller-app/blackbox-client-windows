namespace Blackbox.Client
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
