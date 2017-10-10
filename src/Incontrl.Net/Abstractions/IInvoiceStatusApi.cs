using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceStatusApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        Task<InvoiceStatus> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<InvoiceStatus> UpdateAsync(UpdateInvoiceStatusRequest status, CancellationToken cancellationToken = default(CancellationToken));
    }
}
