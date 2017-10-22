using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class BankAccountApi : IBankAccountApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IBankAccountTransactionsApi> _bankAccountTransactionsApi;
        private readonly Lazy<IBankAccountTransactionApi> _bankAccountTransactionApi;

        public BankAccountApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _bankAccountTransactionsApi = new Lazy<IBankAccountTransactionsApi>(() => new BankAccountTransactionsApi(_clientBase));
            _bankAccountTransactionApi = new Lazy<IBankAccountTransactionApi>(() => new BankAccountTransactionApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string BankAccountId { get; set; }

        public Task<BankAccount> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<BankAccount>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}", cancellationToken);

        public Task<BankAccount> UpdateAsync(BankAccount request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<BankAccount, BankAccount>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}", request, cancellationToken);

        public IBankAccountTransactionsApi Transactions() {
            var bankAccountTransactionsApi = _bankAccountTransactionsApi.Value;
            bankAccountTransactionsApi.SubscriptionId = SubscriptionId;
            bankAccountTransactionsApi.BankAccountId = BankAccountId;

            return bankAccountTransactionsApi;
        }

        public IBankAccountTransactionApi Transaction(Guid transactionId) {
            var bankAccountTransactionApi = _bankAccountTransactionApi.Value;
            bankAccountTransactionApi.SubscriptionId = SubscriptionId;
            bankAccountTransactionApi.BankAccountId = BankAccountId;
            bankAccountTransactionApi.BankTransactionId = transactionId.ToString();

            return bankAccountTransactionApi;
        }
    }
}
