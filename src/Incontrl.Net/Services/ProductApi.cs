using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class ProductApi : IProductApi
    {
        private ClientBase _clientBase;

        public ProductApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string ProductId { get; set; }

        public Task<JsonResponse<Product>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) {
            throw new NotImplementedException();
        }

        public async Task<JsonResponse<Product>> UpdateAsync(UpdateProductRequest product, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateProductRequest, Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/products/{ProductId}", product, cancellationToken);
    }
}
