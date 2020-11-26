using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IDocumentLinesApi
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
        string LineId { get; set; }

        /// <summary>
        /// Updates the classification of the specidied Line.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DocumentLine> UpdateClassification(UpdateDocumentLineRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
