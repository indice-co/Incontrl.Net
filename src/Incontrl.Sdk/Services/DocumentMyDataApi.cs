﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class DocumentMyDataApi : IDocumentMyDataApi
    {
        private readonly ClientBase _clientBase;

        public DocumentMyDataApi(ClientBase clientBase) {
            _clientBase = clientBase;
        }

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task<MyDataResult> CancelAsync(CancellationToken cancellationToken = default) =>
            _clientBase.PostAsync<object, MyDataResult>($"subscriptions/{SubscriptionId}/my-data/documents/{DocumentId}/cancel", null, cancellationToken);

        public Task<MyDataResult> SendAsync(SubmitInvoiceRequest request = null, CancellationToken cancellationToken = default) =>
            _clientBase.PostAsync<SubmitInvoiceRequest, MyDataResult>($"subscriptions/{SubscriptionId}/my-data/documents/{DocumentId}", request ?? new SubmitInvoiceRequest(), cancellationToken);

        public Task UpdateAsync(UpdateMarkRequest request, CancellationToken cancellationToken = default) {
            return _clientBase.PutAsync<UpdateMarkRequest, object>($"subscriptions/{SubscriptionId}/my-data/documents/{DocumentId}", request ?? new UpdateMarkRequest(), cancellationToken);
        }
    }
}
