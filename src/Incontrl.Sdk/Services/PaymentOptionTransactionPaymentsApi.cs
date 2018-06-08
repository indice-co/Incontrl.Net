using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionTransactionPaymentsApi : IPaymentOptionTransactionPaymentsApi
    {
        private readonly ClientBase _clientBase;

        public PaymentOptionTransactionPaymentsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }
        public string TransactionId { get; set; }

        public Task<Payment> CreateAsync(Payment request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<Payment, Payment>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions/{TransactionId}/payments", request, cancellationToken);

        public Task<ResultSet<Payment>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Payment>>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions/{TransactionId}/payments", options, cancellationToken);
    }
}
