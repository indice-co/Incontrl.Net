using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class BankAccountsApi : IBankAccountsApi
    {
        private readonly ClientBase _clientBase;

        public BankAccountsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<BankAccount> CreateAsync(BankAccount request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<BankAccount, BankAccount>($"subscriptions/{SubscriptionId}/bank-accounts", request, cancellationToken);

        public Task<ResultSet<BankAccount>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<BankAccount>>($"subscriptions/{SubscriptionId}/bank-accounts", options, cancellationToken);
    }
}
