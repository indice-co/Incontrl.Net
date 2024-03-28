using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IContactApi
    {
        string SubscriptionId { get; set; }
        string ContactId { get; set; }

        /// <summary>
        /// Gets a specific contact by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Contact> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a specific contact's information.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateContactRequest"/> that contains information about the contact to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Contact> UpdateAsync(Contact request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an instance of class ContactCompaniesApi, that provides functionality to retrieve the companies of the specific contact when an document has been created for it.
        /// </summary>
        IContactCompaniesApi Companies();
    }
}
