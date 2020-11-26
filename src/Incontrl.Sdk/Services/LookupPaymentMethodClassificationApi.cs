using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    class LookupPaymentMethodClassificationApi : ILookupPaymentMethodClassificationApi
    {
        private readonly ClientBase _clientBase;

        public LookupPaymentMethodClassificationApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            _clientBase.GetAsync<ResultSet<Classification>>("classifications/payment-methods");
    }
}
