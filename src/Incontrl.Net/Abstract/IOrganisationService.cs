using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IOrganisationService
    {
        /// <summary>
        /// Gets a list of all organisations of a subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<ResultSet<Organisation>>> GetAsync(Guid subscriptionId, ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets an organisation by it's unique id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="organisationId">The unique id of the organisation.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<JsonResponse<Organisation>> GetByIdAsync(Guid subscriptionId, Guid organisationId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="organisation"></param>
        /// <param name="cancellationToken"></param>
        Task<JsonResponse<Organisation>> CreateAsync(Guid subscriptionId, CreateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="organisationId"></param>
        /// <param name="organisation"></param>
        /// <param name="cancellationToken"></param>
        Task<JsonResponse<Organisation>> UpdateAsync(Guid subscriptionId, Guid organisationId, UpdateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken));
    }
}
