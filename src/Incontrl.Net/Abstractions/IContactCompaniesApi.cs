using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IContactCompaniesApi
    {
        string SubscriptionId { get; set; }
        string ContactId { get; set; }
        Task<ResultSet<Organisation>> GetAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
