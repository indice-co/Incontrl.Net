using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class LookupPlansApi : ILookupEntryApi
    {
        private readonly ClientBase _clientBase;

        public LookupPlansApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<LookupEntry>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
            => _clientBase.GetAsync<ResultSet<LookupEntry>>("plans/lookup");
    }
}
