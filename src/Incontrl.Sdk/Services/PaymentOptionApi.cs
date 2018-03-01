using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionApi : IPaymentOptionApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IPaymentOptionTransactionsApi> _paymentOptionTransactionsApi;
        private readonly Lazy<IPaymentOptionTransactionApi> _paymentOptionTransactionApi;
        private readonly Lazy<IPaymentOptionDocumentTypesApi> _paymentOptionDocumentTypesApi;

        public PaymentOptionApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _paymentOptionTransactionsApi = new Lazy<IPaymentOptionTransactionsApi>(() => new PaymentOptionTransactionsApi(_clientBase));
            _paymentOptionTransactionApi = new Lazy<IPaymentOptionTransactionApi>(() => new PaymentOptionTransactionApi(_clientBase));
            _paymentOptionDocumentTypesApi = new Lazy<IPaymentOptionDocumentTypesApi>(() => new PaymentOptionDocumentTypesApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }

        public IPaymentOptionDocumentTypesApi DocumentTypes() {
            var paymentOptionDocumentTypesApi = _paymentOptionDocumentTypesApi.Value;
            paymentOptionDocumentTypesApi.SubscriptionId = SubscriptionId;
            paymentOptionDocumentTypesApi.PaymentOptionId = PaymentOptionId;

            return paymentOptionDocumentTypesApi;
        }

        public Task<PaymentOption> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<PaymentOption>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}", cancellationToken);

        public IPaymentOptionTransactionApi Transactions(Guid transactionId) {
            var paymentOptionTransactionApi = _paymentOptionTransactionApi.Value;
            paymentOptionTransactionApi.SubscriptionId = SubscriptionId;
            paymentOptionTransactionApi.PaymentOptionId = PaymentOptionId;
            paymentOptionTransactionApi.TransactionId = transactionId.ToString();

            return paymentOptionTransactionApi;
        }

        public IPaymentOptionTransactionsApi Transactions() {
            var paymentOptionTransactionsApi = _paymentOptionTransactionsApi.Value;
            paymentOptionTransactionsApi.SubscriptionId = SubscriptionId;
            paymentOptionTransactionsApi.PaymentOptionId = PaymentOptionId;

            return paymentOptionTransactionsApi;
        }

        public Task<PaymentOption> UpdateAsync(PaymentOption request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<PaymentOption, PaymentOption>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}", request, cancellationToken);
    }
}
