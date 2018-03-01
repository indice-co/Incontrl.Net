using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypePaymentOptionsApi : IDocumentTypePaymentOptions
    {
        private readonly ClientBase _clientBase;

        public DocumentTypePaymentOptionsApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentTypeId { get; set; }

        public Task<PaymentOption> CreateAsync(PaymentOption request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<PaymentOption, PaymentOption>($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/payment-options", request, cancellationToken);

        public Task<ResultSet<PaymentOption>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<PaymentOption>>($"subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}/payment-options", options, cancellationToken);
    }
}
