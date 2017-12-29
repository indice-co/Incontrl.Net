using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class ProductApi : IProductApi
    {
        private readonly ClientBase _clientBase;

        public ProductApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string ProductId { get; set; }

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.DeleteAsync($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/products/{ProductId}", cancellationToken);

        public Task<Product> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<Product>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/products/{ProductId}", cancellationToken);

        public Task<Product> UpdateAsync(Product request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<Product, Product>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/products/{ProductId}", request, cancellationToken);
    }
}
