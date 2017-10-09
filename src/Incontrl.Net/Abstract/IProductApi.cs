using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstract
{
    public interface IProductApi
    {
        string SubscriptionId { get; set; }
        string ProductId { get; set; }
        Task<JsonResponse<Product>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Product>> UpdateAsync(UpdateProductRequest product, CancellationToken cancellationToken = default(CancellationToken));
    }
}
