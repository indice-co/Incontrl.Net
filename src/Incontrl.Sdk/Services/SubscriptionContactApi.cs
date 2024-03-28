using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionContactApi(ClientBase clientBase) : ISubscriptionContactApi
    {
        public string SubscriptionId { get; set; }

        public Task<Contact> GetAsync(CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<Contact>($"subscriptions/{SubscriptionId}/contact", cancellationToken);

        public Task<Contact> UpdateAsync(Contact request, CancellationToken cancellationToken = default) => 
            clientBase.PutAsync<Contact, Contact>($"subscriptions/{SubscriptionId}/contact", request, cancellationToken);
    }
}
