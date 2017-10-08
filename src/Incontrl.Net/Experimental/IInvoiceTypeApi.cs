using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface IInvoiceTypeApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        Task<JsonResponse<InvoiceType>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<InvoiceType>> UpdateAsync(UpdateInvoiceTypeRequest type, CancellationToken cancellationToken = default(CancellationToken));
    }
}
