using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IContactCompaniesApi
    {
        string SubscriptionId { get; set; }
        string ContactId { get; set; }

        /// <summary>
        /// Retrieves a list of the companies of a specific contact when an document has been created for it.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions{OrganisationFilter}"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default);
    }
}
