using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        Task<Invoice> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<Invoice> UpdateAsync(UpdateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
        IInvoiceDocumentApi As(InvoiceFormat format);
        IInvoiceStatusApi Status();
        IInvoiceTrackingApi Trackings();
        IInvoiceTypeApi Type();
    }
}
