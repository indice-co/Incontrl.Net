using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IOrganisationsApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Retrieves a list of the available organisations.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions{OrganisationFilter}"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new organisation for the specified subscription.
        /// </summary>
        /// <param name="organisation">An object of type <see cref="CreateOrganisationRequest"/> that contains information about the organisation to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Organisation> CreateAsync(Organisation request, CancellationToken cancellationToken = default);
    }
}
