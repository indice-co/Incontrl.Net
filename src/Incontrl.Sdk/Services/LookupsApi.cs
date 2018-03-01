using System;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class LookupsApi : ILookupsApi
    {
        private readonly Lazy<ILookupEntryApi> _lookupTimeZonesApi;
        private readonly Lazy<ILookupEntryApi> _lookupCountriesApi;
        private readonly Lazy<ILookupEntryApi> _lookupCurrenciesApi;

        public LookupsApi(Func<ClientBase> clientBaseFactory) {
            var clientBase = clientBaseFactory();
            _lookupTimeZonesApi = new Lazy<ILookupEntryApi>(() => new LookupTimeZonesApi(clientBase));
            _lookupCountriesApi = new Lazy<ILookupEntryApi>(() => new LookupCountriesApi(clientBase));
            _lookupCurrenciesApi = new Lazy<ILookupEntryApi>(() => new LookupCurrenciesApi(clientBase));
        }

        public ILookupEntryApi Countries() => _lookupCountriesApi.Value;

        public ILookupEntryApi Currencies() => _lookupCurrenciesApi.Value;

        public ILookupEntryApi Plans() {
            throw new NotImplementedException();
        }

        public ILookupEntryApi TimeZones() => _lookupTimeZonesApi.Value;
    }
}
