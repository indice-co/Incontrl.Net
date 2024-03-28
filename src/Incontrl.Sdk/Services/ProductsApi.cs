using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class ProductsApi(ClientBase clientBase) : IProductsApi
    {
        public string SubscriptionId { get; set; }

        public Task<Product> CreateAsync(Product request, CancellationToken cancellationToken = default) => 
            clientBase.PostAsync<Product, Product>($"subscriptions/{SubscriptionId}/products", request, cancellationToken);

        public Task<ResultSet<Product>> ListAsync(ListOptions<ProductListFilter> options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<ResultSet<Product>>($"subscriptions/{SubscriptionId}/products", options, cancellationToken);
    }
}
