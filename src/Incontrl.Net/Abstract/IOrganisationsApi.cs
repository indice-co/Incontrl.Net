using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IOrganisationsApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<ResultSet<Organisation>>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Organisation>> CreateAsync(CreateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken));
    }
}
