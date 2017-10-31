using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionTransactionPaymentsApi : IPaymentOptionTransactionPaymentsApi
    {
        private readonly ClientBase _clientBase;

        public PaymentOptionTransactionPaymentsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }
        public string TransactionId { get; set; }

        public Task<Transaction> CreateAsync(Transaction request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<Transaction, Transaction>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions/{TransactionId}/payments", request, cancellationToken);

        public Task<ResultSet<Transaction>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Transaction>>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions/{TransactionId}/payments", options, cancellationToken);
    }
}
