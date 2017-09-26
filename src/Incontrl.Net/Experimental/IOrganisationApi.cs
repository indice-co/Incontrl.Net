using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface IOrganisationApi
    {
        Task<JsonResponse<Organisation>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Organisation>> UpdateAsync(UpdateOrganisationRequest company, CancellationToken cancellationToken = default(CancellationToken));
    }
}