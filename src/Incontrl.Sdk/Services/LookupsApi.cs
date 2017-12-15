using System;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class LookupsApi : ILookupsApi
    {
        private readonly Lazy<ILookupTimeZonesApi> _lookupTimeZonesApi;

        public LookupsApi(ClientBase clientBase) => _lookupTimeZonesApi = new Lazy<ILookupTimeZonesApi>(() => new LookupTimeZonesApi(clientBase));

        public ILookupTimeZonesApi TimeZones() => _lookupTimeZonesApi.Value;
    }
}
