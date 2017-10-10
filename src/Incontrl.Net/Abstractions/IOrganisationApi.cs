using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IOrganisationApi
    {
        string SubscriptionId { get; set; }
        string OrganisationId { get; set; }
        Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<Organisation> UpdateAsync(UpdateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken));
    }
}
