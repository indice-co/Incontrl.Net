using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductApi
    {
        /// <summary>
        /// The id of the subscription.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// The id of the product.
        /// </summary>
        string ProductId { get; set; }

        /// <summary>
        /// Gets a product by it's unique id.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Product> GetAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a specific product's information.
        /// </summary>
        /// <param name="request">An object if type <see cref="Product"/>that contains information about the product to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Product> UpdateAsync(Product request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a specific product.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default);
    }
}
