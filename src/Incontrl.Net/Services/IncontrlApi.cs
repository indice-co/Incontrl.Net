using System;
using Incontrl.Net.Abstract;
using Incontrl.Net.Services;

namespace Incontrl.Net
{
    public sealed class IncontrlApi
    {
        // Private fields.
        private ClientBase _clientBase;
        private Lazy<ISubscriptionService> _subscriptionService;
        private Lazy<IContactService> _contactService;
        private Lazy<IInvoiceService> _invoiceService;
        private Lazy<IInvoiceTypeService> _invoiceTypeService;
        private Lazy<IOrganisationService> _organisationService;
        private Lazy<IProductService> _productService;

        /// <summary>
        /// Class overloaded constructor.
        /// </summary>
        /// <param name="clientName">The name of the registered client.</param>
        /// <param name="clientSecret">The secret key of the client.</param>
        /// <param name="userName">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="apiVersion">The version of the API you want to use (e.x v1).</param>
        public IncontrlApi(string clientName, string clientSecret, string userName, string password, string apiVersion = null) {
            _clientBase = new ClientBase(apiVersion == null ? Api.BASE_ADDRESS : $"{Api.BASE_ADDRESS}/{apiVersion}", clientName, clientSecret, userName, password);
            // Lazy load available services.
            _subscriptionService = new Lazy<ISubscriptionService>(() => new SubscriptionService(_clientBase));
            _contactService = new Lazy<IContactService>(() => new ContactService(_clientBase));
            _invoiceService = new Lazy<IInvoiceService>(() => new InvoiceService(_clientBase));
            _invoiceTypeService = new Lazy<IInvoiceTypeService>(() => new InvoiceTypeService(_clientBase));
            _organisationService = new Lazy<IOrganisationService>(() => new OrganisationService(_clientBase));
            _productService = new Lazy<IProductService>(() => new ProductService(_clientBase));
        }

        public ISubscriptionService Subscriptions => _subscriptionService.Value;
        public IContactService Contacts => _contactService.Value;
        public IInvoiceService Invoices => _invoiceService.Value;
        public IInvoiceTypeService InvoiceTypes => _invoiceTypeService.Value;
        public IOrganisationService Organisations => _organisationService.Value;
        public IProductService Products => _productService.Value;
    }
}
