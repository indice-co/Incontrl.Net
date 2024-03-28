﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class DocumentPaymentsApi : IDocumentPaymentsApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IDocumentPaymentTransactionApi> _documentPaymentTransactionApi;

        public DocumentPaymentsApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _documentPaymentTransactionApi = new Lazy<IDocumentPaymentTransactionApi>(() => new DocumentPaymentTransactionApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string DocumentId { get; set; }

        public Task<Payment> CreateAsync(Payment request, CancellationToken cancellationToken = default) =>
            _clientBase.PostAsync<Payment, Payment>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/payments", request, cancellationToken);

        public Task<ResultSet<Payment>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            _clientBase.GetAsync<ResultSet<Payment>>($"subscriptions/{SubscriptionId}/documents/{DocumentId}/payments", options, cancellationToken);

        public IDocumentPaymentTransactionApi Transactions(Guid transactionId) {
            var documentPaymentTransactionApi = _documentPaymentTransactionApi.Value;
            documentPaymentTransactionApi.SubscriptionId = SubscriptionId;
            documentPaymentTransactionApi.DocumentId = DocumentId;
            documentPaymentTransactionApi.TransactionId = transactionId.ToString();

            return documentPaymentTransactionApi;
        }
    }
}
