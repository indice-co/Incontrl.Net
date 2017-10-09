using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IInvoiceTrackingApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        Task<JsonResponse<ResultSet<InvoiceTracking>>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Tracker>> CreateAsync(CreateInvoiceTrackingRequest tracking, CancellationToken cancellationToken = default(CancellationToken));
    }
}
