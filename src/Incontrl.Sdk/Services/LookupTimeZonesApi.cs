using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupTimeZonesApi : ILookupTimeZonesApi
    {
        private readonly ClientBase _clientBase;

        public LookupTimeZonesApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<TimeZone>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<TimeZone>>("timezones");
    }
}
