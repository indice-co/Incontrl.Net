using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class ProductApi : IProductApi
    {
        private readonly ClientBase _clientBase;

        public ProductApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string ProductId { get; set; }

        public Task<Product> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<Product>($"subscriptions/{SubscriptionId}/products/{ProductId}", cancellationToken);

        public Task<Product> UpdateAsync(UpdateProductRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<UpdateProductRequest, Product>($"subscriptions/{SubscriptionId}/products/{ProductId}", request, cancellationToken);
    }
}
