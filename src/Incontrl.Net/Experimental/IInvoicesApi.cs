using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Experimental
{
    public interface IInvoicesApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<ResultSet<Invoice>>> ListAsync(ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Invoice>> CreateAsync(CreateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken));
    }
}
