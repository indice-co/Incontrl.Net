using System;

namespace Incontrl.Sdk.Models
{
    public class ReconciliationConfig
    {
        public TimeSpan? BackwardsLookup { get; set; }
        public string Algorithm { get; set; }
        public string[] InvoiceTypes { get; set; }
    }
}
