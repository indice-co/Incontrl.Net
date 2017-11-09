using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionContactApi : ISubscriptionContactApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionContactApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Contact> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<Contact>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/contact", cancellationToken);

        public Task<Contact> UpdateAsync(UpdateContactRequest request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PutAsync<UpdateContactRequest, Contact>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/contact", request, cancellationToken);
    }
}
