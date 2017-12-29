using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IProductApi
    {
        string SubscriptionId { get; set; }
        string ProductId { get; set; }

        /// <summary>
        /// Gets a product by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Product> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Updates a specific product's information.
        /// </summary>
        /// <param name="request">An object if type <see cref="UpdateProductRequest"/>that contains information about the product to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Product> UpdateAsync(Product request, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes a specific product.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
