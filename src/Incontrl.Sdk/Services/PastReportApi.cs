using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class PastReportApi : IPastReportApi
    {
        private readonly ClientBase _clientBase;

        public PastReportApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<Report> CreateAsync(ReportType type, ReportingFrequency frequency, int month, int year, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<object, Report>($"subscriptions/{SubscriptionId}/past-reports/types/{type}/frequencies/{frequency}?position={month}&year={year}", null, cancellationToken);
    }
}
