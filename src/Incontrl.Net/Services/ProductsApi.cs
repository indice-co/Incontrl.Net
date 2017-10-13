using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ProductsApi : IProductsApi
    {
        private readonly ClientBase _clientBase;

        public ProductsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<Product> CreateAsync(CreateProductRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateProductRequest, Product>($"subscriptions/{SubscriptionId}/products", request, cancellationToken);

        public async Task<ResultSet<Product>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Product>>($"subscriptions/{SubscriptionId}/products", options, cancellationToken);
    }
}
