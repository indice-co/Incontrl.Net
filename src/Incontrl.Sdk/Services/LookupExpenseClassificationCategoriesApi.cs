using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    class LookupExpenseClassificationCategoriesApi : ILookupExpenseClassificationCategoriesApi
    {
        private readonly ClientBase _clientBase;

        public LookupExpenseClassificationCategoriesApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Classification>>("classifications/expenses/categories");
    }
}
