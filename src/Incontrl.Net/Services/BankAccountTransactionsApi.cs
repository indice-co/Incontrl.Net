using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class BankAccountTransactionsApi : IBankAccountTransactionsApi
    {
        private readonly ClientBase _clientBase;

        public BankAccountTransactionsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string BankAccountId { get; set; }

        public Task<BankTransaction> CreateAsync(BankTransaction request, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.PostAsync<BankTransaction, BankTransaction>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions", request, cancellationToken);

        public Task CreateAsync(BulkLoadTransactionsRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<BulkLoadTransactionsRequest, string>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions", request, cancellationToken);

        public Task<ResultSet<BankTransaction>> ListAsync(ListOptions<TransactionFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<BankTransaction>>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions", options, cancellationToken);
    }
}
