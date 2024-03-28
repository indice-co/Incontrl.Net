using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionsApi(ClientBase clientBase) : IPaymentOptionsApi
    {
        public string SubscriptionId { get; set; }

        public Task<PaymentOption> CreateAsync(PaymentOption request, CancellationToken cancellationToken = default) =>
            clientBase.PostAsync<PaymentOption, PaymentOption>($"subscriptions/{SubscriptionId}/payment-options", request, cancellationToken);

        public Task<ResultSet<PaymentOption>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<PaymentOption>>($"subscriptions/{SubscriptionId}/payment-options", options, cancellationToken);
    }
}
