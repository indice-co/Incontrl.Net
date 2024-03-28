using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class PaymentOptionDocumentTypesApi(ClientBase clientBase) : IPaymentOptionDocumentTypesApi
    {
        public string SubscriptionId { get; set; }
        public string PaymentOptionId { get; set; }

        public Task<ResultSet<DocumentType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<DocumentType>>($"subscriptions/{SubscriptionId}/payment-options/{PaymentOptionId}/document-types", options, cancellationToken);
    }
}
