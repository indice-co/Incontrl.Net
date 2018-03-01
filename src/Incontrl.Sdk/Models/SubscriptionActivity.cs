using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A class that describes important properties of a subscription's activity.
    /// </summary>
    public class SubscriptionActivity
    {
        /// <summary>
        /// Subscription's id.
        /// </summary>
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Subscription's alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Subscription's legal name.
        /// </summary>
        public string LegalName { get; set; }

        /// <summary>
        /// Subscription's country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Subscription's time zone.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// The status of a subscription.
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// The number of documents that have been issued.
        /// </summary>
        public int Documents { get; set; }
    }
}
