using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface ISubscriptionInvoiceTypeApi
    {
        string SubscriptionId { get; set; }
        string InvoiceTypeId { get; set; }
        Task<SubscriptionInvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<SubscriptionInvoiceType> UpdateAsync(UpdateSubscriptionInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken));
        IInvoiceTypeTemplateApi Template();
    }
}
