using System;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class LookupsApi : ILookupsApi
    {
        private readonly Lazy<ILookupTimeZonesApi> _lookupTimeZonesApi;
        private readonly Lazy<ILookupCountriesApi> _lookupCountriesApi;
        private readonly Lazy<ILookupCurrenciesApi> _lookupCurrenciesApi;
        private readonly Lazy<ILookupPlansApi> _lookupPlansApi;
        private readonly Lazy<ILookupCountriesDefaultsApi> _lookupCountriesDefaultsApi;

        public LookupsApi(Func<ClientBase> clientBaseFactory) {
            var clientBase = clientBaseFactory();
            _lookupTimeZonesApi = new Lazy<ILookupTimeZonesApi>(() => new LookupTimeZonesApi(clientBase));
            _lookupCountriesApi = new Lazy<ILookupCountriesApi>(() => new LookupCountriesApi(clientBase));
            _lookupCurrenciesApi = new Lazy<ILookupCurrenciesApi>(() => new LookupCurrenciesApi(clientBase));
            _lookupPlansApi = new Lazy<ILookupPlansApi>(() => new LookupPlansApi(clientBase));
            _lookupCountriesDefaultsApi = new Lazy<ILookupCountriesDefaultsApi>(() => new LookupCountriesDefaultsApi(clientBase));
        }

        public ILookupCountriesApi Countries() => _lookupCountriesApi.Value;

        public ILookupCountriesDefaultsApi Countries(string countryIso) {
            var lookupCountriesDefaultsApi = _lookupCountriesDefaultsApi.Value;
            lookupCountriesDefaultsApi.CountryIso = countryIso;
            return lookupCountriesDefaultsApi;
        }

        public ILookupCurrenciesApi Currencies() => _lookupCurrenciesApi.Value;

        public ILookupPlansApi Plans() => _lookupPlansApi.Value;

        public ILookupTimeZonesApi TimeZones() => _lookupTimeZonesApi.Value;
    }
}
