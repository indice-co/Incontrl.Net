﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class MetricsApi : IMetricsApi
    {
        private readonly ClientBase _clientBase;

        public MetricsApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<MetricsRecord, Metrics>> ListAsync(ListOptions<RangeFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<MetricsRecord, Metrics>>($"{_clientBase.ApiAddress}subscriptions/all/metrics", cancellationToken);
    }
}
