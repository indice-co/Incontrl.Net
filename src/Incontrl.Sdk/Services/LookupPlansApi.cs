using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupPlansApi(ClientBase clientBase) : ILookupPlansApi
    {
        public Task<ResultSet<Plan>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default)
            => clientBase.GetAsync<ResultSet<Plan>>("plans");
    }
}
