using System;

namespace Incontrl.Sdk.Models
{
    public class MetricsRecord
    {
        public DateTime Timestamp { get; set; }
        public TimeSpan Period { get; set; }
        public Metrics Metrics { get; set; }
    }
}
