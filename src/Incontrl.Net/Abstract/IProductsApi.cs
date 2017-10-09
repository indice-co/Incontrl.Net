using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IProductsApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<ResultSet<Product>>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Product>> CreateAsync(CreateProductRequest product, CancellationToken cancellationToken = default(CancellationToken));
    }
}
