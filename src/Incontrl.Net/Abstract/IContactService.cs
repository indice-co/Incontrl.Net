using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IContactService
    {
        /// <summary>
        /// Gets a list of contacts that are associated with a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<ResultSet<Contact>>> GetAsync(Guid subscriptionId, ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a contact by it's id for a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Contact>> GetByIdAsync(Guid subscriptionId, Guid contactId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the companies that are associated with a specific subscription and contact.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<ResultSet<Organisation>>> GetCompaniesAsync(Guid subscriptionId, Guid contactId, ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new contact for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contact">An object of type <see cref="CreateContactRequest"/> that contains information about the newly created contact.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Contact>> CreateAsync(Guid subscriptionId, CreateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a specific contact for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="contact">An object of type <see cref="UpdateContactRequest"/> that contains information about the contact to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Organisation>> UpdateAsync(Guid subscriptionId, Guid contactId, UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken));
    }
}
