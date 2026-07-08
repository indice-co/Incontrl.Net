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
        /// <summary>
        /// No billing frequency.
        /// </summary>
        Never = 0,
        /// <summary>
        /// Monthly billing.
        /// </summary>
        Monthly = 1,
        /// <summary>
        /// Quarterly billing (every 3 months).
        /// </summary>
        Quarterly = 3,
        /// <summary>
        /// Semesterly/Semi-annual billing (every 6 months).
        /// </summary>
        Semesterly = 6,
        /// <summary>
        /// Annual billing (every 12 months).
        /// </summary>
        Annually = 12
    }
}
