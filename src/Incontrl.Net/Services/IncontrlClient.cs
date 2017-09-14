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
        private ClientBase _clientBase;

        /// <summary>
        /// Class overloaded constructor.
        /// </summary>
        /// <param name="clientName">The name of the registered client.</param>
        /// <param name="clientSecret">The secret key of the client.</param>
        public IncontrlClient(string clientName, string clientSecret, string apiVersion = null) {
            _clientBase = new ClientBase(apiVersion == null ? Api.BaseAddress : $"{Api.BaseAddress}/{apiVersion}", clientName, clientSecret);
        }

        #region Subscriptions

        #region GET Operations
        /// <summary>
        /// Gets a list of all subscriptions.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Subscription>>> GetSubscriptionsAsync(ListOptions<SubscriptionListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Subscription>>(Api.SubscriptionEndpointsPrefix, options, cancellationToken);

        /// <summary>
        /// Finds a subscription by it's unique id.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Subscription>> GetSubscriptionByIdAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Subscription>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}", cancellationToken);


        /// <summary>
        /// Finds the company information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Organisation>> GetSubscriptionCompanyAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Organisation>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/company", cancellationToken);

        /// <summary>
        /// Finds the contact information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Contact>> GetSubscriptionContactAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Contact>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/contact", cancellationToken);

        /// <summary>
        /// Retrieves status information for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionStatus>> GetSubscriptionStatusAsync(Guid subscriptionId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<SubscriptionStatus>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/status", cancellationToken);
        #endregion

        #region POST Operations
        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        /// <param name="subscription">An object of type <see cref="CreateSubscriptionRequest"/> containing information about the new subscription.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Subscription>> CreateSubscriptionAsync(CreateSubscriptionRequest subscription, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PostAsync<CreateSubscriptionRequest, Subscription>(Api.SubscriptionEndpointsPrefix, subscription, cancellationToken);
        #endregion

        #region PUT Operations
        /// <summary>
        /// Updates the company information for a specified subscription.
        /// </summary>
        /// <param name="company">An object of type <see cref="UpdateCompanyRequest"/> containing information about the subscription's company to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Organisation>> UpdateSubscriptionCompanyAsync(Guid subscriptionId, UpdateCompanyRequest company, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateCompanyRequest, Organisation>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/company", company, cancellationToken);

        /// <summary>
        /// Updates the status information for a specified subscription.
        /// </summary>
        /// <param name="status">An object of type <see cref="UpdateSubscriptionStatusRequest"/> containing information about the subscription's status to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<SubscriptionStatus>> UpdateSubscriptionStatusAsync(Guid subscriptionId, UpdateSubscriptionStatusRequest status, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.PutAsync<UpdateSubscriptionStatusRequest, SubscriptionStatus>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/status", status, cancellationToken);
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
            await _clientBase.GetAsync<ResultSet<Contact>>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/contacts", options, cancellationToken);

        /// <summary>
        /// Gets a contact by it's id for a specific subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Contact>> GetContactByIdAsync(Guid subscriptionId, Guid contactId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Contact>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/contacts/{contactId}", cancellationToken);

        /// <summary>
        /// Gets the companies that are associated with a specific subscription and contact.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="contactId">The unique id of the contact.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Organisation>>> GetCompaniesByContactIdAsync(Guid subscriptionId, Guid contactId, ListOptions<OrganisationFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Organisation>>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/contacts/{contactId}/companies", options, cancellationToken);
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
            await _clientBase.PostAsync<CreateContactRequest, Contact>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/contacts", contact, cancellationToken);
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
            await _clientBase.PutAsync<UpdateContactRequest, Organisation>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/contacts/{contactId}", contact, cancellationToken);
        #endregion

        #endregion

        #region Contacts

        #region GET Operations
        /// <summary>
        /// Gets a list of the invoices that are associated with a subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="options"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<ResultSet<Invoice>>> GetInvoicesAsync(Guid subscriptionId, ListOptions<InvoiceListFilter> options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<ResultSet<Invoice>>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/invoices", options, cancellationToken);

        /// <summary>
        /// Gets a specific invoice for a specified subscription.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<Invoice>> GetInvoiceByIdAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Invoice>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/invoices/{invoiceId}", cancellationToken);

        /// <summary>
        /// Gets the status of a specific invoice.
        /// </summary>
        /// <param name="subscriptionId">The unique id of the subscription.</param>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        public async Task<JsonResponse<InvoiceStatus>> GetInvoiceStatusAsync(Guid subscriptionId, Guid invoiceId, CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<InvoiceStatus>($"{Api.SubscriptionEndpointsPrefix}/{subscriptionId}/invoices/{invoiceId}/status", cancellationToken);
        #endregion

        #endregion
    }
}