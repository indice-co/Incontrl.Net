namespace Incontrl.Net.Models
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

    public class UpdateSubscriptionCompanyRequest : UpdateOrganisationRequest { }

    public class UpdateSubscriptionStatusRequest
    {
        public SubscriptionStatus Status { get; set; }
    }

    public class SubscriptionListFilter
    {
        public string Code { get; set; }
    }
}