using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Experimental
{
    public interface IOrganisationsApi
    {
        Task<JsonResponse<ResultSet<Organisation>>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Organisation>> CreateAsync(CreateOrganisationRequest subscription, CancellationToken cancellationToken = default(CancellationToken));
    }
}