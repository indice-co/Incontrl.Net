using System;

namespace Incontrl.Net.Models
{
    public class ReconciliationConfig
    {
        public TimeSpan? BackwardsLookup { get; set; }
        public string Algorithm { get; set; }
        public string[] InvoiceTypes { get; set; }
    }
}
