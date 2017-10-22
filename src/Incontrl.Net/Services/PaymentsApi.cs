using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class PaymentsApi : IPaymentsApi
    {
        private readonly ClientBase _clientBase;

        public PaymentsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string BankAccountId { get; set; }
        public string BankTransactionId { get; set; }

        public Task<Payment> CreateAsync(Payment request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<Payment, Payment>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions/{BankTransactionId}/payments", request, cancellationToken);

        public Task<ResultSet<Payment>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Payment>>($"subscriptions/{SubscriptionId}/bank-accounts/{BankAccountId}/transactions/{BankTransactionId}/payments", options, cancellationToken);
    }
}
