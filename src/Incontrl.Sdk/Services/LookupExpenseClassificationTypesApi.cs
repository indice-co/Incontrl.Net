using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    class LookupExpenseClassificationTypesApi(ClientBase clientBase) : ILookupExpenseClassificationTypesApi
    {
        public Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<Classification>>("classifications/expenses/types");
    }
}
