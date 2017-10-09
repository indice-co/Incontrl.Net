using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstract
{
    public interface IOrganisationApi
    {
        string SubscriptionId { get; set; }
        string OrganisationId { get; set; }
        Task<JsonResponse<Organisation>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Organisation>> UpdateAsync(UpdateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken));
    }
}
