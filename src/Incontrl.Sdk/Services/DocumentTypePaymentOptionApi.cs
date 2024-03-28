using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypePaymentOptionApi(ClientBase clientBase) : IDocumentTypePaymentOption
    {
        public string SubscriptionId { get; set; }
        public string DocumentTypeId { get; set; }
        public string PaymentOptionId { get; set; }

        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            clientBase.DeleteAsync($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/payment-options/{PaymentOptionId}", cancellationToken);
    }
}
