using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface ILookupCountriesDefaultsApi
    {
        string CountryIso { get; set; }
        Task<CountryDefaults> GetAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
