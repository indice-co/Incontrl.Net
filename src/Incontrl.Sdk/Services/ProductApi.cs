using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class ProductApi(ClientBase clientBase) : IProductApi
    {
        public string SubscriptionId { get; set; }
        public string ProductId { get; set; }

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            clientBase.DeleteAsync($"subscriptions/{SubscriptionId}/products/{ProductId}", cancellationToken);

        public Task<Product> GetAsync(CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<Product>($"subscriptions/{SubscriptionId}/products/{ProductId}", cancellationToken);

        public Task<Product> UpdateAsync(Product request, CancellationToken cancellationToken = default) =>
            clientBase.PutAsync<Product, Product>($"subscriptions/{SubscriptionId}/products/{ProductId}", request, cancellationToken);
    }
}
