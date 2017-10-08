using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Experimental
{
    public interface IContactCompaniesApi
    {
        string SubscriptionId { get; set; }
        string ContactId { get; set; }
        Task<JsonResponse<ResultSet<Organisation>>> GetAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
