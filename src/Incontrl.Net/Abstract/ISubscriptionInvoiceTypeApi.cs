using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstract
{
    public interface ISubscriptionInvoiceTypeApi
    {
        string SubscriptionId { get; set; }
        string InvoiceTypeId { get; set; }
        Task<JsonResponse<SubscriptionInvoiceType>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<SubscriptionInvoiceType>> UpdateAsync(UpdateSubscriptionInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken));
        IInvoiceTypeTemplateApi Template();
    }
}
