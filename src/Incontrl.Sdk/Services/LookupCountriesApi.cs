using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupCountriesApi(ClientBase clientBase) : ILookupCountriesApi
    {
        public Task<ResultSet<CountryInfo>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<CountryInfo>>("countries");
    }
}
