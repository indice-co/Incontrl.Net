using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupPlansApi : ILookupPlansApi
    {
        private readonly ClientBase _clientBase;

        public LookupPlansApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<PlanInfo>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
            => _clientBase.GetAsync<ResultSet<PlanInfo>>("plans");
    }
}
