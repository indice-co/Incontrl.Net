using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ProductService : IProductService
    {
        private ClientBase _clientBase;

        public ProductService(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<JsonResponse<Product>> CreateAsync(Guid subscriptionId, CreateProductRequest product, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateProductRequest, Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products", product, cancellationToken);

        public async Task<JsonResponse<Product>> GetByIdAsync(Guid subscriptionId, Guid productId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products/{productId}", cancellationToken);

        public async Task<JsonResponse<ResultSet<Product>>> GetAsync(Guid subscriptionId, ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Product>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products", options, cancellationToken);

        public async Task<JsonResponse<Product>> UpdateAsync(Guid subscriptionId, Guid productId, UpdateProductRequest product, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateProductRequest, Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products/{productId}", product, cancellationToken);
    }
}
