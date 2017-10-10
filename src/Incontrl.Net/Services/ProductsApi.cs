using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ProductsApi : IProductsApi
    {
        private ClientBase _clientBase;

        public ProductsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public async Task<Product> CreateAsync(CreateProductRequest product, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateProductRequest, Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/products", product, cancellationToken);

        public async Task<ResultSet<Product>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Product>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/products", options, cancellationToken);
    }
}
