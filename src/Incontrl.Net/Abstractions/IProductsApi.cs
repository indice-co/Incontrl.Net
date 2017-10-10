using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IProductsApi
    {
        string SubscriptionId { get; set; }
        Task<ResultSet<Product>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<Product> CreateAsync(CreateProductRequest product, CancellationToken cancellationToken = default(CancellationToken));
    }
}
