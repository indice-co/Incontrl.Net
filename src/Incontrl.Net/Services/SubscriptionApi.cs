using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionApi : ISubscriptionApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<ISubscriptionContactApi> _subscriptionContactApi;
        private readonly Lazy<IContactsApi> _subscriptionContactsApi;
        private readonly Lazy<IContactApi> _contactApi;
        private readonly Lazy<ISubscriptionStatusApi> _subscriptionStatusApi;
        private readonly Lazy<ISubscriptionCompanyApi> _subscriptionCompanyApi;
        private readonly Lazy<IInvoicesApi> _invoicesApi;
        private readonly Lazy<IInvoiceApi> _invoiceApi;
        private readonly Lazy<IInvoiceTypesApi> _invoiceTypesApi;
        private readonly Lazy<IInvoiceTypeApi> _invoiceTypeApi;
        private readonly Lazy<IOrganisationsApi> _organisationsApi;
        private readonly Lazy<IOrganisationApi> _organisationApi;
        private readonly Lazy<IProductsApi> _productsApi;
        private readonly Lazy<IProductApi> _productApi;

        public SubscriptionApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _subscriptionContactApi = new Lazy<ISubscriptionContactApi>(() => new SubscriptionContactApi(_clientBase));
            _subscriptionContactsApi = new Lazy<IContactsApi>(() => new ContactsApi(_clientBase));
            _contactApi = new Lazy<IContactApi>(() => new ContactApi(_clientBase));
            _subscriptionStatusApi = new Lazy<ISubscriptionStatusApi>(() => new SubscriptionStatusApi(_clientBase));
            _subscriptionCompanyApi = new Lazy<ISubscriptionCompanyApi>(() => new SubscriptionCompanyApi(_clientBase));
            _invoicesApi = new Lazy<IInvoicesApi>(() => new InvoicesApi(_clientBase));
            _invoiceApi = new Lazy<IInvoiceApi>(() => new InvoiceApi(_clientBase));
            _invoiceTypeApi = new Lazy<IInvoiceTypeApi>(() => new InvoiceTypeApi(_clientBase));
            _invoiceTypesApi = new Lazy<IInvoiceTypesApi>(() => new InvoiceTypesApi(_clientBase));
            _organisationsApi = new Lazy<IOrganisationsApi>(() => new OrganisationsApi(_clientBase));
            _organisationApi = new Lazy<IOrganisationApi>(() => new OrganisationApi(_clientBase));
            _productsApi = new Lazy<IProductsApi>(() => new ProductsApi(_clientBase));
            _productApi = new Lazy<IProductApi>(() => new ProductApi(_clientBase));
        }

        public string SubscriptionId { get; set; }

        public ISubscriptionCompanyApi Company() {
            var subscriptionCompanyApi = _subscriptionCompanyApi.Value;
            subscriptionCompanyApi.SubscriptionId = SubscriptionId;

            return subscriptionCompanyApi;
        }

        public ISubscriptionContactApi Contact() {
            var subscriptionContactApi = _subscriptionContactApi.Value;
            subscriptionContactApi.SubscriptionId = SubscriptionId;

            return subscriptionContactApi;
        }

        public IContactApi Contact(Guid contactId) {
            var contactApi = _contactApi.Value;
            contactApi.SubscriptionId = SubscriptionId;
            contactApi.ContactId = contactId.ToString();

            return contactApi;
        }

        public IContactsApi Contacts() {
            var subscriptionContactsApi = _subscriptionContactsApi.Value;
            subscriptionContactsApi.SubscriptionId = SubscriptionId;

            return subscriptionContactsApi;
        }

        public async Task<Subscription> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Subscription>($"subscriptions/{SubscriptionId}", cancellationToken);

        public IInvoiceApi Invoice(Guid invoiceId) {
            var invoiceApi = _invoiceApi.Value;
            invoiceApi.SubscriptionId = SubscriptionId;
            invoiceApi.InvoiceId = invoiceId.ToString();

            return invoiceApi;
        }

        public IInvoicesApi Invoices() {
            var invoicesApi = _invoicesApi.Value;
            invoicesApi.SubscriptionId = SubscriptionId;

            return invoicesApi;
        }

        public IInvoiceTypeApi InvoiceType(Guid invoiceTypeId) {
            var invoiceTypeApi = _invoiceTypeApi.Value;
            invoiceTypeApi.SubscriptionId = SubscriptionId;
            invoiceTypeApi.InvoiceTypeId = invoiceTypeId.ToString();

            return invoiceTypeApi;
        }

        public IInvoiceTypesApi InvoiceTypes() {
            var invoiceTypesApi = _invoiceTypesApi.Value;
            invoiceTypesApi.SubscriptionId = SubscriptionId;

            return invoiceTypesApi;
        }

        public IOrganisationApi Organisation(Guid organisationId) {
            var organisationApi = _organisationApi.Value;
            organisationApi.SubscriptionId = SubscriptionId;
            organisationApi.OrganisationId = organisationId.ToString();

            return organisationApi;
        }

        public IOrganisationsApi Organisations() {
            var organisationsApi = _organisationsApi.Value;
            organisationsApi.SubscriptionId = SubscriptionId;

            return organisationsApi;
        }

        public IProductApi Product(Guid productId) {
            var productApi = _productApi.Value;
            productApi.SubscriptionId = SubscriptionId;
            productApi.ProductId = productId.ToString();

            return productApi;
        }

        public IProductsApi Products() {
            var productsApi = _productsApi.Value;
            productsApi.SubscriptionId = SubscriptionId;

            return productsApi;
        }

        public ISubscriptionStatusApi Status() {
            var subscriptionStatusApi = _subscriptionStatusApi.Value;
            subscriptionStatusApi.SubscriptionId = SubscriptionId;

            return subscriptionStatusApi;
        }
    }
}
