using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentsApi : IPaymentsApi
    {
        private readonly ClientBase _clientBase;

        public PaymentsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string BankAccountId { get; set; }
        public string BankTransactionId { get; set; }

        public Task<Payment> CreateAsync(Payment request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<Payment, Payment>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions/{BankTransactionId}/payments", request, cancellationToken);

        public Task<ResultSet<Payment>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Payment>>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions/{BankTransactionId}/payments", options, cancellationToken);
    }
}
