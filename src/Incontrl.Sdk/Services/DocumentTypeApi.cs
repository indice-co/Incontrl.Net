using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentTypeApi : IDocumentTypeApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IDocumentTypeTemplateApi> _templateApi;
        private readonly Lazy<IDocumentTypePaymentOptions> _documentTypePaymentOptions;
        private readonly Lazy<IDocumentTypePaymentOption> _documentTypePaymentOption;

        public DocumentTypeApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _templateApi = new Lazy<IDocumentTypeTemplateApi>(() => new DocumentTypeTemplateApi(_clientBase));
            _documentTypePaymentOptions = new Lazy<IDocumentTypePaymentOptions>(() => new DocumentTypePaymentOptionsApi(_clientBase));
            _documentTypePaymentOption = new Lazy<IDocumentTypePaymentOption>(() => new DocumentTypePaymentOptionApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string DocumentTypeId { get; set; }

        public Task<DocumentType> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<DocumentType>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}", cancellationToken);

        public Task<DocumentType> UpdateAsync(UpdateDocumentTypeRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<UpdateDocumentTypeRequest, DocumentType>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}", request, cancellationToken);

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.DeleteAsync($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/document-types/{DocumentTypeId}", cancellationToken);

        public IDocumentTypeTemplateApi Template() {
            var templateApi = _templateApi.Value;
            templateApi.SubscriptionId = SubscriptionId;
            templateApi.DocumentTypeId = DocumentTypeId;

            return templateApi;
        }

        public IDocumentTypePaymentOptions PaymentOptions() {
            var documentTypePaymentOptions = _documentTypePaymentOptions.Value;
            documentTypePaymentOptions.SubscriptionId = SubscriptionId;
            documentTypePaymentOptions.DocumentTypeId = DocumentTypeId;

            return documentTypePaymentOptions;
        }

        public IDocumentTypePaymentOption PaymentOptions(Guid paymentOptionId) {
            var documentTypePaymentOption = _documentTypePaymentOption.Value;
            documentTypePaymentOption.SubscriptionId = SubscriptionId;
            documentTypePaymentOption.DocumentTypeId = DocumentTypeId;
            documentTypePaymentOption.PaymentOptionId = paymentOptionId.ToString();

            return documentTypePaymentOption;
        }
    }
}
