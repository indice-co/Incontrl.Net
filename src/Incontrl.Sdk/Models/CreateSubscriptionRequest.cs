using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Request model for subscriptions.
    /// </summary>
    public class CreateSubscriptionRequest
    {
        /// <summary>
        /// Custom lookup key for this subscription.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The company alias - future replacement for the subscriptionId.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// The Default timezone in which the invoices are created.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// The company entity assosiated with the subscription.
        /// </summary>
        public Organisation Company { get; set; }

        /// <summary>
        /// The primary contact for the subscription (billing info will be added at some point).
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// The primary contact for the subscription (billing info will be added at some point).
        /// </summary>
        public string Plan { get; set; }

        /// <summary>
        /// Notes about this subscription.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Custom data for this subscription.
        /// </summary>
        [JsonProperty(NamingStrategyType = typeof(DefaultNamingStrategy))]
        public object CustomData { get; set; }
    }

    public enum SubscriptionType
    {
        Sandbox = 0,
        Trial = 1,
        Basic = 3,
        Pro = 4,
        Custom = 5
    }
}
