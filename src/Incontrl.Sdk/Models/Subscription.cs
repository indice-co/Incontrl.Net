﻿using System;

namespace Incontrl.Sdk.Models
{
    public class Subscription
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
        /// The default timezone in which the documents are created.
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// Subscription status.
        /// </summary>
        public SubscriptionStatus Status { get; set; }
        /// <summary>
        /// The company entity assosiated with the subscription.
        /// </summary>
        public Organisation Company { get; set; }
        /// <summary>
        /// The primary contact for the subscription (billing info will be added at some point).
        /// </summary>
        public Contact Contact { get; set; }
        /// <summary>
        /// Information about the subscription plan.
        /// </summary>
        public Plan Plan { get; set; }
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
