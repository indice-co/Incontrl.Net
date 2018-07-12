using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class Plan
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public BillingFrequency? BillingFrequency { get; set; }
        public string RichText { get; set; }
        public UiHint UiHint { get; set; }
        public List<Service> Services { get; set; }
        public List<LimitPolicy> Limits { get; set; }
        public bool Unavailable { get; set; }
    }

    public enum BillingFrequency : short
    {
        Monthly = 1,
        Quarterly = 3,
        Biannually = 6,
        Annually = 12
    }
}
