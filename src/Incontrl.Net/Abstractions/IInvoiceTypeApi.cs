using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTypeApi
    {
        string SubscriptionId { get; set; }
        string InvoiceTypeId { get; set; }

        Task<InvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<InvoiceType> UpdateAsync(UpdateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken));
        IInvoiceTypeTemplateApi Template();
    }
}
