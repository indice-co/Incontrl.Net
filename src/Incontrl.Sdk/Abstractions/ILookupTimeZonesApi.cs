﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface ILookupTimeZonesApi
    {
        Task<ResultSet<TimeZone>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}