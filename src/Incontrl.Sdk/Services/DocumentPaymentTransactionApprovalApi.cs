using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentPaymentTransactionApprovalApi(ClientBase clientBase) : IDocumentPaymentTransactionApprovalApi
    {
        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }
        public string TransactionId { get; set; }

        public Task UpdateAsync(UpdateApprovalRequest request, CancellationToken cancellationToken = default) =>
            clientBase.PutAsync<UpdateApprovalRequest, Document>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/payments/{TransactionId}/approval", request, cancellationToken);
    }
}
