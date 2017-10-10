using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IProductApi
    {
        string SubscriptionId { get; set; }
        string ProductId { get; set; }
        Task<Product> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<Product> UpdateAsync(UpdateProductRequest product, CancellationToken cancellationToken = default(CancellationToken));
    }
}
