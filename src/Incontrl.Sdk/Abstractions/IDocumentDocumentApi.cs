using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentDocumentApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string DocumentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DocumentFormat Format { get; set; }

        /// <summary>
        /// Downloads an Document as a Stream in the specified mime type.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<FileResult> DownloadAsync(CancellationToken cancellationToken = default);
    }
}
