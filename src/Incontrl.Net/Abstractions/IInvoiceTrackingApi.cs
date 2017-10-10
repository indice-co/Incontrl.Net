using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTrackingApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        Task<ResultSet<InvoiceTracking>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<Tracker> CreateAsync(CreateInvoiceTrackingRequest tracking, CancellationToken cancellationToken = default(CancellationToken));
    }
}
