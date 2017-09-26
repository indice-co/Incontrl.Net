using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class InvoiceService : IInvoiceService
    {
        private ClientBase _clientBase;

        public InvoiceService(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<JsonResponse<Invoice>> CreateAsync(Guid subscriptionId, CreateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateInvoiceRequest, Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices", invoice, cancellationToken);

        public async Task DeleteAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.DeleteAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}", cancellationToken);

        public async Task<JsonResponse<Invoice>> GetByIdAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}", cancellationToken);

        public async Task<FileResult> GetByIdAsync(Guid subscriptionId, Guid invoiceId, InvoiceFormat format, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetStreamAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}", new { format = "pdf" }, cancellationToken);

        public async Task<JsonResponse<ResultSet<Invoice>>> GetAsync(Guid subscriptionId, ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<Invoice>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices", options, cancellationToken);

        public async Task<JsonResponse<InvoiceStatus>> GetStatusAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<InvoiceStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/status", cancellationToken);

        public async Task<JsonResponse<InvoiceType>> GetTypeAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<InvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/type", cancellationToken);

        public async Task<JsonResponse<Invoice>> UpdateAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateInvoiceRequest, Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}", invoice, cancellationToken);

        public async Task<JsonResponse<InvoiceStatus>> UpdateStatusAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateInvoiceStatusRequest, InvoiceStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/status", status, cancellationToken);

        public async Task<JsonResponse<InvoiceType>> UpdateTypeAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceTypeRequest type, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateInvoiceTypeRequest, InvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/type", type, cancellationToken);
    }
}
