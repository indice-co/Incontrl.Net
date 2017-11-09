using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionsApi : IPaymentOptionsApi
    {
        private readonly ClientBase _clientBase;

        public PaymentOptionsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<PaymentOption> CreateAsync(PaymentOption request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<PaymentOption, PaymentOption>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/payment-options", request, cancellationToken);

        public Task<ResultSet<PaymentOption>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<PaymentOption>>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/payment-options", options, cancellationToken);
    }
}
