using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IOrganisationApi
    {
        string SubscriptionId { get; set; }
        string OrganisationId { get; set; }

        /// <summary>
        /// Gets an organisation's information by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates an organisation's information.
        /// </summary>
        /// <param name="request">An object of type <see cref="UpdateOrganisationRequest"/> that contains information about the organisation to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Organisation> UpdateAsync(UpdateOrganisationRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
