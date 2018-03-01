using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionTransactionApi : IPaymentOptionTransactionApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IPaymentOptionTransactionPaymentsApi> _paymentOptionTransactionPaymentsApi;

        public PaymentOptionTransactionApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _paymentOptionTransactionPaymentsApi = new Lazy<IPaymentOptionTransactionPaymentsApi>(() => new PaymentOptionTransactionPaymentsApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }
        public string TransactionId { get; set; }

        public Task<Transaction> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<Transaction>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/transactions/{TransactionId}/payments", cancellationToken);

        public IPaymentOptionTransactionPaymentsApi Payments() {
            var paymentOptionTransactionPaymentsApi = _paymentOptionTransactionPaymentsApi.Value;
            paymentOptionTransactionPaymentsApi.SubscriptionId = SubscriptionId;
            paymentOptionTransactionPaymentsApi.PaymentOptionId = PaymentOptionId;
            paymentOptionTransactionPaymentsApi.TransactionId = TransactionId;

            return paymentOptionTransactionPaymentsApi;
        }
    }
}
