namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILookupsApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ILookupTimeZonesApi TimeZones();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ILookupCountriesApi Countries();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryIso"></param>
        /// <returns></returns>
        ILookupCountriesDefaultsApi Countries(string countryIso);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ILookupCurrenciesApi Currencies();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ILookupPlansApi Plans();
    }
}
