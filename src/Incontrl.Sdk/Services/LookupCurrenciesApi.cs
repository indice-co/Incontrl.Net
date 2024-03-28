using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupCurrenciesApi(ClientBase clientBase) : ILookupCurrenciesApi
    {
        public Task<ResultSet<CurrencyInfo>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<CurrencyInfo>>("currencies");
    }
}
