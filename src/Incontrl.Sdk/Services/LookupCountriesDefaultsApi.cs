using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupCountriesDefaultsApi(ClientBase clientBase) : ILookupCountriesDefaultsApi
    {
        public string CountryIso { get; set; }

        public Task<CountryDefaults> GetAsync(ListOptions options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<CountryDefaults>($"countries/{CountryIso}/defaults", cancellationToken);
    }
}
