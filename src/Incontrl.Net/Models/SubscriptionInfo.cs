using System;

namespace Incontrl.Net.Models
{
    public class SubscriptionInfo
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Custom lookup key for this subscription.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Unique alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// The company entity assosiated with the subscription.
        /// </summary>
        public OrganisationInfo Company { get; set; }

        /// <summary>
        /// The primary contact for the subscription (billing info will be added at some point).
        /// </summary>
        public ContactInfo Contact { get; set; }

        /// <summary>
        /// Notes about this subscription.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Custom data for this subscription.
        /// </summary>
        public object CustomData { get; set; }
    }
}