using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// Incontrl's core API interface.
    /// </summary>
    public interface ICoreApi : IApi
    {
        /// <summary>
        /// Creates an instance of class SubscriptionsApi, that provides functionality to list or create subscriptions.
        /// </summary>
        ISubscriptionsApi Subscriptions();

        /// <summary>
        /// Creates an instance of class SubscriptionApi, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionId">The subscription's unique id.</param>
        ISubscriptionApi Subscription(Guid subscriptionId);

        /// <summary>
        /// Creates an instance of class SubscriptionApi, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionAlias">The subscription's unique alias.</param>
        ISubscriptionApi Subscription(string subscriptionAlias);

        /// <summary>
        /// Creates an instance of class LicenseApi, that provides functionality to retrieve InContrl's license information.
        /// </summary>
        ILicenseApi License();

        /// <summary>
        /// Configures some settings for calling the API.
        /// </summary>
        /// <param name="apiAddress">The address of Incontrl's API.</param>
        /// <param name="authorityAddress">The address of the authority server.</param>
        ICoreApi Configure(string apiAddress, string authorityAddress = null);
    }
}
