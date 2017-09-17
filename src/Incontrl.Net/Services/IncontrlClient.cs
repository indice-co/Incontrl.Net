using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    public sealed class IncontrlClient
    {
        // Private fields.
        private ClientBase _clientBase;

        /// <summary>
        /// Class overloaded constructor.
        /// </summary>
        /// <param name="clientName">The name of the registered client.</param>
        /// <param name="clientSecret">The secret key of the client.</param>
        public IncontrlClient(string clientName, string clientSecret, string apiVersion = null) =>
            _clientBase = new ClientBase(apiVersion == null ? Api.BASE_ADDRESS : $"{Api.BASE_ADDRESS}/{apiVersion}", clientName, clientSecret);

        #region Subscriptions

        #region GET Operations
        /// <summary>
        /// Gets a list of all subscriptions.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Subscription>>> GetSubscriptionsAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Subscription>>(Api.SUBSCRIPTION_ENDPOINTS_PREFIX, options, cancellationToken);

        /// <summary>
        /// Finds a subscription by it's unique id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Subscription>> GetSubscriptionByIdAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Subscription>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}", cancellationToken);


        /// <summary>
        /// Finds the company information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Organisation>> GetSubscriptionCompanyAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/company", cancellationToken);

        /// <summary>
        /// Finds the contact information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Contact>> GetSubscriptionContactAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contact", cancellationToken);

        /// <summary>
        /// Retrieves status information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionStatus>> GetSubscriptionStatusAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<SubscriptionStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/status", cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="subscription">An object of type <see cref="CreateSubscriptionRequest"/> containing information about the new subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Subscription>> CreateSubscriptionAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>(Api.SUBSCRIPTION_ENDPOINTS_PREFIX, subscription, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// Updates the company information for a specified subscription.
        /// </summary>
        /// <param name="company">An object of type <see cref="UpdateCompanyRequest"/> containing information about the subscription's company to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Organisation>> UpdateSubscriptionCompanyAsync(Guid subscriptionId, UpdateCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateCompanyRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/company", company, cancellationToken);

        /// <summary>
        /// Updates the status information for a specified subscription.
        /// </summary>
        /// <param name="status">An object of type <see cref="UpdateSubscriptionStatusRequest"/> containing information about the subscription's status to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionStatus>> UpdateSubscriptionStatusAsync(Guid subscriptionId, UpdateSubscriptionStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateSubscriptionStatusRequest, SubscriptionStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/status", status, cancellationToken);
        #endregion

        #endregion

        #region Contacts

        #region GET Operations
        /// <summary>
        /// Gets a list of contacts that are associated with a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Contact>>> GetContactsAsync(Guid subscriptionId, ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Contact>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts", options, cancellationToken);

        /// <summary>
        /// Gets a contact by it's id for a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Contact>> GetContactByIdAsync(Guid subscriptionId, Guid contactId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts/{contactId}", cancellationToken);

        /// <summary>
        /// Gets the companies that are associated with a specific subscription and contact.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Organisation>>> GetCompaniesByContactIdAsync(Guid subscriptionId, Guid contactId, ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Organisation>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts/{contactId}/companies", options, cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// Creates a new contact for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contact">An object of type <see cref="CreateContactRequest"/> that contains information about the newly created contact.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Contact>> CreateContactAsync(Guid subscriptionId, CreateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateContactRequest, Contact>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts", contact, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// Updates a specific contact for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="contact">An object of type <see cref="UpdateContactRequest"/> that contains information about the contact to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Organisation>> UpdateContactAsync(Guid subscriptionId, Guid contactId, UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateContactRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/contacts/{contactId}", contact, cancellationToken);
        #endregion

        #endregion

        #region Invoices

        #region GET Operations
        /// <summary>
        /// Gets a list of the invoices that are associated with a subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Invoice>>> GetInvoicesAsync(Guid subscriptionId, ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Invoice>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices", options, cancellationToken);

        /// <summary>
        /// Gets a specific invoice for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Invoice>> GetInvoiceByIdAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}", cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="invoiceId"></param>
        /// <param name="format"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<InvoiceDocument>> GetInvoiceByIdAsync(Guid subscriptionId, Guid invoiceId, InvoiceFormat format, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<InvoiceDocument>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}", new { format = "pdf" }, cancellationToken);

        /// <summary>
        /// Gets the status of a specific invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<InvoiceStatus>> GetInvoiceStatusAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<InvoiceStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/status", cancellationToken);

        /// <summary>
        /// Gets type information for a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<InvoiceType>> GetInvoiceTypeAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<InvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/type", cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// Creates a new invoice for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoice">An object of type <see cref="CreateInvoiceRequest"/> that contains information about the newly created invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Invoice>> CreateInvoiceAsync(Guid subscriptionId, CreateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateInvoiceRequest, Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices", invoice, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// Updates a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="invoice">An object of type <see cref="UpdateInvoiceRequest"/> that contains information about the invoice to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Invoice>> UpdateInvoiceAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceRequest invoice, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateInvoiceRequest, Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}", invoice, cancellationToken);

        /// <summary>
        /// Changes the status of a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="status">An object of type <see cref="UpdateInvoiceStatusRequest"/> that contains information about the status of the invoice to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<InvoiceStatus>> UpdateInvoiceStatusAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateInvoiceStatusRequest, InvoiceStatus>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/status", status, cancellationToken);

        /// <summary>
        /// Updates the type of a specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="type">An object of type <see cref="UpdateInvoiceTypeRequest"/> that contains information about the status of the invoice to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<InvoiceType>> UpdateInvoiceTypeAsync(Guid subscriptionId, Guid invoiceId, UpdateInvoiceTypeRequest type, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateInvoiceTypeRequest, InvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceId}/type", type, cancellationToken);
        #endregion

        #region DELETE Operations
        /// <summary>
        /// Deletes the specified invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<bool>> DeleteInvoiceAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.DeleteAsync<bool>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}", cancellationToken);
        #endregion

        #endregion

        #region Invoice Types

        #region GET Operations
        /// <summary>
        /// Gets the invoice types for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<SubscriptionInvoiceType>>> GetInvoiceTypesAsync(Guid subscriptionId, ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<SubscriptionInvoiceType>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types", options, cancellationToken);

        /// <summary>
        /// Gets a specific invoice type by using it's id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceTypeId">The unique id of the invoice type.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionInvoiceType>> GetInvoiceTypeByIdAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<SubscriptionInvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types/{invoiceTypeId}", cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// Creates a new invoice type for the specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceType">An object of type <see cref="CreateInvoiceTypeRequest"/> that contains information about the newly created invoice type.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionInvoiceType>> CreateInvoiceTypeAsync(Guid subscriptionId, CreateInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateInvoiceTypeRequest, SubscriptionInvoiceType>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types", invoiceType, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// Updates a specific invoice type by it's id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceTypeId">The unique id of the invoice type.</param>
        /// <param name="invoiceType"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Invoice>> UpdateInvoiceTypeAsync(Guid subscriptionId, Guid invoiceTypeId, UpdateSubscriptionInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateSubscriptionInvoiceTypeRequest, Invoice>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoices/{invoiceTypeId}", invoiceType, cancellationToken);
        #endregion

        #region DELETE Operations
        /// <summary>
        /// Deletes a specific invoice type by it's id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceTypeId">The unique id of the invoice type.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<bool>> DeleteInvoiceTypeAsync(Guid subscriptionId, Guid invoiceTypeId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.DeleteAsync<bool>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/invoice-types/{invoiceTypeId}", cancellationToken);
        #endregion

        #endregion

        #region Organisations

        #region GET Operations
        /// <summary>
        /// Gets a list of all organisations of a subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Organisation>>> GetOrganisationsAsync(Guid subscriptionId, ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Organisation>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations", options, cancellationToken);

        /// <summary>
        /// Gets an organisation by it's unique id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="organisationId">The unique id of the organisation.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Organisation>> GetOrganisationByIdAsync(Guid subscriptionId, Guid organisationId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations/{organisationId}", cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="organisation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<Organisation>> CreateOrganisationAsync(Guid subscriptionId, CreateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateOrganisationRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations", organisation, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="organisationId"></param>
        /// <param name="organisation"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<Organisation>> UpdateOrganisationAsync(Guid subscriptionId, Guid organisationId, UpdateOrganisationRequest organisation, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateOrganisationRequest, Organisation>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/organisations/{organisationId}", organisation, cancellationToken);
        #endregion

        #endregion

        #region Products

        #region GET Operations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<ResultSet<Product>>> GetProductsAsync(Guid subscriptionId, ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Product>>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products", options, cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="productId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<Product>> GetProductByIdAsync(Guid subscriptionId, Guid productId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products/{productId}", cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<Product>> CreateProductAsync(Guid subscriptionId, CreateProductRequest product, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateProductRequest, Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products", product, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <param name="productId"></param>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<JsonResponse<Product>> UpdateProductAsync(Guid subscriptionId, Guid productId, UpdateProductRequest product, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateProductRequest, Product>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{subscriptionId}/products/{productId}", product, cancellationToken);
        #endregion

        #endregion
    }
}
