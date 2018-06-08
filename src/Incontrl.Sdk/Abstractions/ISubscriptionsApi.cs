using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Services;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubscriptionsApi
    {
        /// <summary>
        /// A property that indicates if we want to retrieve information on cross subscription level.
        /// </summary>
        bool GlobalAccess { get; set; }

        /// <summary>
        /// Retrieves a list of my subscriptions.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions{SubscriptionListFilter}"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Subscription>> ListAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateSubscriptionRequest"/> that contains information about the subscription to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Subscription> CreateAsync(CreateSubscriptionRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates an instance of class <see cref="MetricsApi"/>, that provides functionality to access subscription metrics.
        /// </summary>
        IMetricsApi Metrics();

        /// <summary>
        /// 
        /// </summary>
        IGlobalPaymentOptionsApi PaymentOptions();

        /// <summary>
        /// Creates an instance of class <see cref="InvitationApi"/>, that provides functionality to send and accept invitations.
        /// </summary>
        /// <param name="invitationId"></param>
        IInvitationApi Invitation(string invitationId);
    }
}
