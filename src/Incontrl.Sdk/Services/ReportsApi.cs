using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class ReportsApi(ClientBase clientBase) : IReportsApi
    {
        public string SubscriptionId { get; set; }

        public Task<Subscription[]> ListAsync(ReportType type, ReportingFrequency? frequency, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<Subscription[]>($"subscriptions/reports/types/{type}/frequencies/{(frequency.HasValue ? frequency.Value.ToString() : string.Empty)}", cancellationToken);
    }
}
