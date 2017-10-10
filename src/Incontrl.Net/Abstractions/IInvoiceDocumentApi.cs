using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceDocumentApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }
        InvoiceFormat Format { get; set; }
        Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
