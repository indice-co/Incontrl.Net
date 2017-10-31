using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentTypeTemplateApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string DocumentTypeId { get; set; }

        /// <summary>
        /// Gets the template file of the specified document type as a Stream.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates the template file of the specified document type.
        /// </summary>
        /// <param name="fileContent">The contents of the template file.</param>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task UploadAsync(byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken));
    }
}
