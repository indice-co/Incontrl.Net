using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceTypeApi : IInvoiceTypeApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IInvoiceTypeTemplateApi> _templateApi;

        public InvoiceTypeApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _templateApi = new Lazy<IInvoiceTypeTemplateApi>(() => new InvoiceTypeTemplateApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string InvoiceTypeId { get; set; }

        public async Task<InvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<InvoiceType>($"subscriptions/{SubscriptionId}/invoice-types/{InvoiceTypeId}", cancellationToken);
        public async Task<InvoiceType> UpdateAsync(UpdateInvoiceTypeRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateInvoiceTypeRequest, InvoiceType>($"subscriptions/{SubscriptionId}/invoice-types/{InvoiceTypeId}", request, cancellationToken);
        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.DeleteAsync($"subscriptions/{SubscriptionId}/invoice-types/{InvoiceTypeId}", cancellationToken);

        public IInvoiceTypeTemplateApi Template() {
            var templateApi = _templateApi.Value;
            templateApi.SubscriptionId = SubscriptionId;
            templateApi.InvoiceTypeId = InvoiceTypeId;
            return templateApi;
        }

    }
}
