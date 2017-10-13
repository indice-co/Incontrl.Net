using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTypeTemplateApi
    {
        string SubscriptionId { get; set; }
        string InvoiceTypeId { get; set; }

        /// <summary>
        /// Gets the template file of the specified invoice type as a Stream.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the template file of the specified invoice type.
        /// </summary>
        /// <param name="fileContent">The contents of the template file expressed as <see cref="byte[]"/>.</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task UploadAsync(byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
