using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentPaymentTransactionApprovalApi : IDocumentPaymentTransactionApprovalApi
    {
        private readonly ClientBase _clientBase;

        public DocumentPaymentTransactionApprovalApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public string TransactionId { get; set; }

        public Task UpdateAsync(UpdateApprovalRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PutAsync<UpdateApprovalRequest, Document>($"{_clientBase.ApiAddress}subscriptions/{SubscriptionId}/documents/{DocumentId}/payments/{TransactionId}/approval", request, cancellationToken);
    }
}
