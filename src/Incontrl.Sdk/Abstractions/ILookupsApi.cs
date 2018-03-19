namespace Incontrl.Sdk.Abstractions
{
    public interface ILookupsApi
    {
        ILookupTimeZonesApi TimeZones();
        ILookupCountriesApi Countries();
        ILookupCurrenciesApi Currencies();
        ILookupPlansApi Plans();
    }
}
