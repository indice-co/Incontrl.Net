using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupTimeZonesApi(ClientBase clientBase) : ILookupTimeZonesApi
    {
        public Task<ResultSet<TimeZone>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<TimeZone>>("timezones");
    }
}
