using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionDocumentTypesApi : IPaymentOptionDocumentTypesApi
    {
        private readonly ClientBase _clientBase;

        public PaymentOptionDocumentTypesApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }

        public Task<ResultSet<DocumentType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<DocumentType>>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/document-types", options, cancellationToken);
    }
}
