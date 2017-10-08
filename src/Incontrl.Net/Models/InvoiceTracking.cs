using System;

namespace Incontrl.Net.Models
{
    public class InvoiceTracking
    {
        public int Reads { get; set; }
        public string Recipient { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastRead { get; set; }
        public Tracker Tracker { get; set; }
    }

    public class Tracker
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string DocumentUrl { get; set; }
    }
}
