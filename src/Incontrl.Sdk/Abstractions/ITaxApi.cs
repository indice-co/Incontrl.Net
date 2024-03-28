using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface ITaxApi
    {
        string SubscriptionId { get; set; }
        string TaxId { get; set; }

        /// <summary>
        /// Gets a tax definition by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<TaxDefinition> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Permanently deletes the specified tax definition.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the specified tax definition.
        /// </summary>
        /// <param name="request">An object of type <see cref="TaxDefinition"/> that contains information about the document type to update.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<TaxDefinition> UpdateAsync(TaxDefinition request, CancellationToken cancellationToken = default);
    }
}
