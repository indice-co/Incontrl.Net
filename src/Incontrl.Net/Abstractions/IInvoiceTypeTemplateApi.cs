using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTypeTemplateApi
    {
        string SubscriptionId { get; set; }
        string InvoiceTypeId { get; set; }
        Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task UploadAsync(byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
