using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class BankAccountTransactionApi : IBankAccountTransactionApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IPaymentsApi> _paymentsApi;

        public BankAccountTransactionApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _paymentsApi = new Lazy<IPaymentsApi>(() => new PaymentsApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string BankAccountId { get; set; }
        public string BankTransactionId { get; set; }

        public Task<BankTransaction> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<BankTransaction>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions/{BankTransactionId}", cancellationToken);

        public IPaymentsApi Payments() {
            var paymentsApi = _paymentsApi.Value;
            paymentsApi.SubscriptionId = SubscriptionId;
            paymentsApi.BankAccountId = BankTransactionId;
            paymentsApi.BankTransactionId = BankTransactionId;

            return paymentsApi;
        }
    }
}
