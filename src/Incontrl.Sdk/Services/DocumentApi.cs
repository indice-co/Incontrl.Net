using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentApi : IDocumentApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IDocumentDocumentApi> _documentDocumentApi;
        private readonly Lazy<IDocumentStatusApi> _documentStatusApi;
        private readonly Lazy<IDocumentTrackingApi> _documentTrackingApi;
        private readonly Lazy<IDocumentDocumentTypeApi> _documentDocumentTypeApi;
        private readonly Lazy<IDocumentPaymentsApi> _documentPaymentsApi;

        public DocumentApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _documentDocumentApi = new Lazy<IDocumentDocumentApi>(() => new DocumentDocumentApi(_clientBase));
            _documentStatusApi = new Lazy<IDocumentStatusApi>(() => new DocumentStatusApi(_clientBase));
            _documentTrackingApi = new Lazy<IDocumentTrackingApi>(() => new DocumentTrackingApi(_clientBase));
            _documentDocumentTypeApi = new Lazy<IDocumentDocumentTypeApi>(() => new DocumentDocumentTypeApi(_clientBase));
            _documentPaymentsApi = new Lazy<IDocumentPaymentsApi>(() => new DocumentPaymentsApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.DeleteAsync($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/documents/{DocumentId}", cancellationToken);

        public Task<Document> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<Document>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/documents/{DocumentId}", cancellationToken);

        public IDocumentDocumentApi As(DocumentFormat format) {
            var documentDocumentApi = _documentDocumentApi.Value;
            documentDocumentApi.SubscriptionId = SubscriptionId;
            documentDocumentApi.DocumentId = DocumentId;
            documentDocumentApi.Format = format;

            return documentDocumentApi;
        }

        public Task<Document> UpdateAsync(UpdateDocumentRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<UpdateDocumentRequest, Document>($"{_clientBase.ApiAddress}/subscriptions/{SubscriptionId}/documents/{DocumentId}", request, cancellationToken);

        public IDocumentStatusApi Status() {
            var documentStatusApi = _documentStatusApi.Value;
            documentStatusApi.SubscriptionId = SubscriptionId;
            documentStatusApi.DocumentId = DocumentId;

            return documentStatusApi;
        }

        public IDocumentTrackingApi Trackings() {
            var documentTrackingApi = _documentTrackingApi.Value;
            documentTrackingApi.SubscriptionId = SubscriptionId;
            documentTrackingApi.DocumentId = DocumentId;

            return documentTrackingApi;
        }

        public IDocumentDocumentTypeApi Type() {
            var documentDocumentTypeApi = _documentDocumentTypeApi.Value;
            documentDocumentTypeApi.SubscriptionId = SubscriptionId;
            documentDocumentTypeApi.DocumentId = DocumentId;

            return documentDocumentTypeApi;
        }

        public IDocumentPaymentsApi Payments() {
            var documentPaymentsApi = _documentPaymentsApi.Value;
            documentPaymentsApi.SubscriptionId = SubscriptionId;
            documentPaymentsApi.DocumentId = DocumentId;

            return documentPaymentsApi;
        }
    }
}
