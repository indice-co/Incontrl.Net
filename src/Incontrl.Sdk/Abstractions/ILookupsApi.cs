namespace Incontrl.Sdk.Abstractions
{
    public interface ILookupsApi
    {
        ILookupEntryApi TimeZones();
        ILookupEntryApi Countries();
        ILookupEntryApi Currencies();
        ILookupEntryApi Plans();
    }
}
