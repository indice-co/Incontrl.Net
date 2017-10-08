using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface IInvoiceStatusApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        Task<JsonResponse<InvoiceStatus>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<InvoiceStatus>> UpdateAsync(UpdateInvoiceStatusRequest status, CancellationToken cancellationToken = default(CancellationToken));
    }
}
