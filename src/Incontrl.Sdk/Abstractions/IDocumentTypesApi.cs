using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentTypesApi
    {
        /// <summary>
        /// 
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Creates a new document type.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateDocumentTypeRequest"/> that contains information about the document type to create.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<DocumentType> CreateAsync(CreateDocumentTypeRequest request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves a list of the available document types.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<DocumentType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
