using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IProductsApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Retrieves a list of the available products.
        /// </summary>
        /// <param name="options">An object of type <see cref="ListOptions"/> that is used to paginate or filter the request.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<ResultSet<Product>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="request">An object of type <see cref="CreateProductRequest"/> that contains information about the new product.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Product> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
