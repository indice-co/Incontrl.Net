using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface ISubscriptionContactApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Gets the contact information that is associated with the subscription.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Contact> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the contact information that is associated with the subscription.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateContactRequest"/> that contains information about the contact to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Contact> UpdateAsync(UpdateContactRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
