using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class InvoiceTypeService : IInvoiceTypeService
    {
        private ClientBase _clientBase;

        public InvoiceTypeService(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<JsonResponse<SubscriptionInvoiceType>> CreateAsync(Guid subscriptionId, CreateInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostAsync<CreateInvoiceTypeRequest, SubscriptionInvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types", invoiceType, cancellationToken);

        public async Task DeleteAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.DeleteAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types/{invoiceTypeId}", cancellationToken);

        public async Task<JsonResponse<SubscriptionInvoiceType>> GetByIdAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<SubscriptionInvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types/{invoiceTypeId}", cancellationToken);

        public async Task<JsonResponse<ResultSet<SubscriptionInvoiceType>>> GetAsync(Guid subscriptionId, ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetAsync<ResultSet<SubscriptionInvoiceType>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types", options, cancellationToken);

        public async Task<FileResult> GetTemplateAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.GetStreamAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types/{invoiceTypeId}/template", cancellationToken);

        public async Task<JsonResponse<Invoice>> UpdateAsync(Guid subscriptionId, Guid invoiceTypeId, UpdateSubscriptionInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PutAsync<UpdateSubscriptionInvoiceTypeRequest, Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceTypeId}", invoiceType, cancellationToken);

        public async Task UpdateTemplateAsync(Guid subscriptionId, Guid invoiceTypeId, byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken)) => 
            await _clientBase.PostFileAsync($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types/{invoiceTypeId}/template", fileContent, fileName, cancellationToken);
    }
}
