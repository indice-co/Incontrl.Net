﻿using System.Threading;
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

        public Task<Report> CreateAsync(ReportingFrequency frequency, ReportType type, int month, int year, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<object, Report>($"subscriptions/{SubscriptionId}/past-reports?frequency={frequency}&position={month}&year={year}&type={type}", null, cancellationToken);
    }
}
