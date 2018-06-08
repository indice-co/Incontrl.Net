using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IContactsApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Retrieves a list of all available registered contacts.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions{ContactFilter}"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Contact>> ListAsync(ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateContactRequest"/> that contains information about the contact to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Contact> CreateAsync(Contact request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
