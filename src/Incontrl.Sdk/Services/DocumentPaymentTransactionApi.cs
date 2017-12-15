using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class DocumentPaymentTransactionApi : IDocumentPaymentTransactionApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IDocumentPaymentTransactionApprovalApi> _documentPaymentTransactionApprovalApi;

        public DocumentPaymentTransactionApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _documentPaymentTransactionApprovalApi = new Lazy<IDocumentPaymentTransactionApprovalApi>(() => new DocumentPaymentTransactionApprovalApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public string TransactionId { get; set; }

        public IDocumentPaymentTransactionApprovalApi Approval() {
            var documentPaymentTransactionApprovalApi = _documentPaymentTransactionApprovalApi.Value;
            documentPaymentTransactionApprovalApi.SubscriptionId = SubscriptionId;
            documentPaymentTransactionApprovalApi.DocumentId = DocumentId;
            documentPaymentTransactionApprovalApi.TransactionId = TransactionId;

            return documentPaymentTransactionApprovalApi;
        }

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.DeleteAsync($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/documents/{DocumentId}/payments/{TransactionId}", cancellationToken);
    }
}
