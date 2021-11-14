using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IDocumentMyDataApi
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        string SubscriptionId { get; set; }
        /// <summary>
        /// The id of the document.
        /// </summary>
        string DocumentId { get; set; }
        /// <summary>
        /// Submits the specified document to Aade.
        /// </summary>
        /// <param name="request">Additional information regarding invoice submission.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<MyDataResult> SendAsync(SubmitInvoiceRequest request = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Cancels the specified document in Aade.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<MyDataResult> CancelAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Updates document marks for AADE.
        /// </summary>
        /// <param name="request">Contains data of updating document marks.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task UpdateAsync(UpdateMarkRequest request, CancellationToken cancellationToken = default);
    }
}
