namespace Incontrl.Sdk.Abstractions
{
    public interface ILookupsApi
    {
        ILookupTimeZonesApi TimeZones();
        ILookupCountriesApi Countries();
        ILookupCountriesDefaultsApi Countries(string countryIso);
        ILookupCurrenciesApi Currencies();
        ILookupPlansApi Plans();
    }
}
