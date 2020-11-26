using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    class LookupDocumentTypeClassificationApi : ILookupDocumentTypeClassificationApi
    {
        private readonly ClientBase _clientBase;

        public LookupDocumentTypeClassificationApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<Classification>>("classifications/document-types");
    }
}
