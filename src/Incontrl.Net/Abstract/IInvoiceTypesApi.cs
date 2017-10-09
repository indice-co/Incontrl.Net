using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IInvoiceTypesApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<SubscriptionInvoiceType>> CreateAsync(CreateInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<ResultSet<SubscriptionInvoiceType>>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
