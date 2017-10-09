using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionInvoiceTypeApi : ISubscriptionInvoiceTypeApi
    {
        private ClientBase _clientBase;
        private Lazy<IInvoiceTypeTemplateApi> _invoiceTypeTemplateApi;

        public SubscriptionInvoiceTypeApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _invoiceTypeTemplateApi = new Lazy<IInvoiceTypeTemplateApi>(() => new InvoiceTypeTemplateApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string InvoiceTypeId { get; set; }

        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.DeleteAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoice-types/{InvoiceTypeId}", cancellationToken);

        public async Task<JsonResponse<SubscriptionInvoiceType>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<SubscriptionInvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoice-types/{InvoiceTypeId}", cancellationToken);

        public IInvoiceTypeTemplateApi Template() {
            var invoiceTypeTemplateApi = _invoiceTypeTemplateApi.Value;
            invoiceTypeTemplateApi.SubscriptionId = SubscriptionId;
            invoiceTypeTemplateApi.InvoiceTypeId = InvoiceTypeId;

            return invoiceTypeTemplateApi;
        }

        public async Task<JsonResponse<SubscriptionInvoiceType>> UpdateAsync(UpdateSubscriptionInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateSubscriptionInvoiceTypeRequest, SubscriptionInvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceTypeId}", invoiceType, cancellationToken);
    }
}
