using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IOrganisationsApi
    {
        string SubscriptionId { get; set; }
        Task<ResultSet<Organisation>> ListAsync(ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<Organisation> CreateAsync(CreateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken));
    }
}
