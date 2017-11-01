using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionTransactionsApi : IPaymentOptionTransactionsApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IPaymentOptionTransactionPaymentsApi> _paymentOptionTransactionPaymentsApi;

        public PaymentOptionTransactionsApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _paymentOptionTransactionPaymentsApi = new Lazy<IPaymentOptionTransactionPaymentsApi>(() => new PaymentOptionTransactionPaymentsApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }

        public Task BulkCreateAsync(BulkLoadTransactionsRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<BulkLoadTransactionsRequest, BulkLoadTransactionsRequest>($"/subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions/bulk", request, cancellationToken);

        public Task<Transaction> CreateAsync(Transaction request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<Transaction, Transaction>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions", request, cancellationToken);

        public Task<ResultSet<Transaction>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Transaction>>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions", cancellationToken);

        public IPaymentOptionTransactionPaymentsApi Payments() {
            var paymentOptionTransactionPaymentsApi = _paymentOptionTransactionPaymentsApi.Value;
            paymentOptionTransactionPaymentsApi.SubscriptionId = SubscriptionId;
            paymentOptionTransactionPaymentsApi.PaymentOptionId = PaymentOptionId;

            return paymentOptionTransactionPaymentsApi;
        }
    }
}
