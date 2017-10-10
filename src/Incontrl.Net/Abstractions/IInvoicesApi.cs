using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoicesApi
    {
        string SubscriptionId { get; set; }
        Task<ResultSet<Invoice>> ListAsync(ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<Invoice> CreateAsync(CreateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken));
    }
}
