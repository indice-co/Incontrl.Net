using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupCountriesApi : ILookupCountriesApi
    {
        private readonly ClientBase _clientBase;

        public LookupCountriesApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<CountryInfo>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<CountryInfo>>("countries");
    }
}
