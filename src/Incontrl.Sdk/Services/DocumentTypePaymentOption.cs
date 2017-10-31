using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypePaymentOption : IDocumentTypePaymentOption
    {
        private readonly ClientBase _clientBase;

        public DocumentTypePaymentOption(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentTypeId { get; set; }
        public string PaymentOptionId { get; set; }

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.DeleteAsync($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/payment-options/{PaymentOptionId}", cancellationToken);
    }
}
