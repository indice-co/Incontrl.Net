using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface IInvoiceApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        Task<JsonResponse<Invoice>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Invoice>> UpdateAsync(UpdateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
        IInvoiceDocumentApi Format(InvoiceFormat format);
        IInvoiceStatusApi Status();
        IInvoiceTrackingApi Trackings();
        IInvoiceTypeApi Type();
    }
}
