using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupCurrenciesApi : ILookupCurrenciesApi
    {
        private readonly ClientBase _clientBase;

        public LookupCurrenciesApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<CurrencyInfo>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<CurrencyInfo>>("currencies");
    }
}
