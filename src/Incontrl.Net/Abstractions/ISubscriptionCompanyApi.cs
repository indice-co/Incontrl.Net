using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface ISubscriptionCompanyApi
    {
        string SubscriptionId { get; set; }
        Task<Organisation> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<Organisation> UpdateAsync(UpdateCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken));
    }
}
