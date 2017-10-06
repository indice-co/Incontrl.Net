using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class SubscriptionService : ISubscriptionService
    {
        private ClientBase _clientBase;

        public SubscriptionService(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<JsonResponse<Subscription>> CreateAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>(Api.SUBSCRIPTION_ENDPOINTS_PREFIX, subscription, cancellationToken);

        public async Task<JsonResponse<ResultSet<Subscription>>> GetAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Subscription>>(Api.SUBSCRIPTION_ENDPOINTS_PREFIX, options, cancellationToken);

        public async Task<JsonResponse<Subscription>> GetByIdAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Subscription>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}", cancellationToken);

        public async Task<JsonResponse<Organisation>> GetCompanyAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/company", cancellationToken);

        public async Task<JsonResponse<Organisation>> UpdateCompanyAsync(Guid subscriptionId, UpdateCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateCompanyRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/company", company, cancellationToken);

        public async Task<JsonResponse<Contact>> GetContactAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contact", cancellationToken);

        public async Task<JsonResponse<SubscriptionStatus>> GetStatusAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<SubscriptionStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/status", cancellationToken);

        public async Task<JsonResponse<SubscriptionStatus>> UpdateStatusAsync(Guid subscriptionId, UpdateSubscriptionStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateSubscriptionStatusRequest, SubscriptionStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/status", status, cancellationToken);
    }
}
