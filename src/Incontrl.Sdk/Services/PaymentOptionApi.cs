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

        public PaymentOptionApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _paymentOptionTransactionsApi = new Lazy<IPaymentOptionTransactionsApi>(() => new PaymentOptionTransactionsApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }

        public Task<PaymentOption> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<PaymentOption>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}", cancellationToken);

        public IPaymentOptionTransactionApi Transactions(Guid transactionId) {
            throw new NotImplementedException();
        }

        public IPaymentOptionTransactionsApi Transactions() {
            var paymentOptionTransactionsApi = _paymentOptionTransactionsApi.Value;
            paymentOptionTransactionsApi.SubscriptionId = SubscriptionId;
            paymentOptionTransactionsApi.PaymentOptionId = PaymentOptionId;

            return paymentOptionTransactionsApi;
        }

        public Task<PaymentOption> UpdateAsync(PaymentOption request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<PaymentOption, PaymentOption>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}", request, cancellationToken);
    }
}
