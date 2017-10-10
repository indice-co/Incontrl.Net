using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface ISubscriptionStatusApi
    {
        string SubscriptionId { get; set; }
        Task<SubscriptionStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<SubscriptionStatus> UpdateAsync(SubscriptionStatus status, CancellationToken cancellationToken = default(CancellationToken));
    }
}
