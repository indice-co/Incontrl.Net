using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Experimental;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class InvoiceApi : IInvoiceApi
    {
        private ClientBase _clientBase;
        private Lazy<IInvoiceDocumentApi> _invoiceDocumentApi;
        private Lazy<IInvoiceStatusApi> _invoiceStatusApi;
        private Lazy<IInvoiceTrackingApi> _invoiceTrackingApi;
        private Lazy<IInvoiceTypeApi> _invoiceTypeApi;

        public InvoiceApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _invoiceDocumentApi = new Lazy<IInvoiceDocumentApi>(() => new InvoiceDocumentApi(_clientBase));
            _invoiceStatusApi = new Lazy<IInvoiceStatusApi>(() => new InvoiceStatusApi(_clientBase));
            _invoiceTrackingApi = new Lazy<IInvoiceTrackingApi>(() => new InvoiceTrackingApi(_clientBase));
            _invoiceTypeApi = new Lazy<IInvoiceTypeApi>(() => new InvoiceTypeApi(_clientBase));
        }

        public string SubscriptionId { get; set; }
        public string InvoiceId { get; set; }

        public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.DeleteAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}", cancellationToken);

        public async Task<JsonResponse<Invoice>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}", cancellationToken);

        public IInvoiceDocumentApi Format(InvoiceFormat format) {
            var invoiceDocumentApi = _invoiceDocumentApi.Value;
            invoiceDocumentApi.SubscriptionId = SubscriptionId;
            invoiceDocumentApi.InvoiceId = InvoiceId;
            invoiceDocumentApi.Format = format;

            return invoiceDocumentApi;
        }

        public async Task<JsonResponse<Invoice>> UpdateAsync(UpdateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateInvoiceRequest, Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}/invoices/{InvoiceId}", invoice, cancellationToken);

        public IInvoiceStatusApi Status() {
            var invoiceStatusApi = _invoiceStatusApi.Value;
            invoiceStatusApi.SubscriptionId = SubscriptionId;
            invoiceStatusApi.InvoiceId = InvoiceId;

            return invoiceStatusApi;
        }

        public IInvoiceTrackingApi Trackings() {
            var invoiceTrackingApi = _invoiceTrackingApi.Value;
            invoiceTrackingApi.SubscriptionId = SubscriptionId;
            invoiceTrackingApi.InvoiceId = InvoiceId;

            return invoiceTrackingApi;
        }

        public IInvoiceTypeApi Type() {
            var invoiceTypeApi = _invoiceTypeApi.Value;
            invoiceTypeApi.SubscriptionId = SubscriptionId;
            invoiceTypeApi.InvoiceId = InvoiceId;

            return invoiceTypeApi;
        }
    }
}
