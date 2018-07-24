using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class ReportsApi : IReportsApi
    {
        private readonly ClientBase _clientBase;

        public ReportsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Service[]> ListAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<Service[]>($"subscriptions/reports", cancellationToken);
    }
}
