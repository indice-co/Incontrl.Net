using System;

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
        /// The culture/language setting for the subscription.
        /// </summary>
        public string Culture { get; set; }
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
        /// The subscription recipe/template for initial setup.
        /// </summary>
        public SubscriptionRecipe? Recipe { get; set; }
        /// <summary>
        /// Notes about this subscription.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Custom data for this subscription.
        /// </summary>
        public object CustomData { get; set; }
    }

    /// <summary>
    /// Subscription recipe/template types for initial configuration.
    /// </summary>
    public enum SubscriptionRecipe
    {
        /// <summary>
        /// Default configuration.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Business services configuration.
        /// </summary>
        BusinessServices = 1,
        /// <summary>
        /// Freelance services configuration.
        /// </summary>
        FreelanceServices = 2,
        /// <summary>
        /// Enterprise configuration.
        /// </summary>
        Enterprise = 3,
        /// <summary>
        /// Goods/products configuration.
        /// </summary>
        Goods = 4
    }
}
