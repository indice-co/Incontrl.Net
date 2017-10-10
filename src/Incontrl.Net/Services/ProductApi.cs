using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
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

        public async Task<Product> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Product>($"subscriptions/{SubscriptionId}/products/{ProductId}", cancellationToken);

        public async Task<Product> UpdateAsync(UpdateProductRequest product, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateProductRequest, Product>($"subscriptions/{SubscriptionId}/products/{ProductId}", product, cancellationToken);
    }
}
