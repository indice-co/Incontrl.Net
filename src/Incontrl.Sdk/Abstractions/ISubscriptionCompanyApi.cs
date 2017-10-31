using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface ISubscriptionCompanyApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Gets the company information that is associated with the subscription.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the company information that is associated with the subscription.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateCompanyRequest"/> that contains information about the subscription's associated company.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Organisation> UpdateAsync(UpdateCompanyRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
