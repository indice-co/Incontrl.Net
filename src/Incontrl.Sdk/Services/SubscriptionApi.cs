using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionApi : ISubscriptionApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<ISubscriptionContactApi> _subscriptionContactApi;
        private readonly Lazy<IContactsApi> _subscriptionContactsApi;
        private readonly Lazy<IContactApi> _contactApi;
        private readonly Lazy<ISubscriptionStatusApi> _subscriptionStatusApi;
        private readonly Lazy<ISubscriptionCompanyApi> _subscriptionCompanyApi;
        private readonly Lazy<IDocumentsApi> _documentsApi;
        private readonly Lazy<IDocumentApi> _documentApi;
        private readonly Lazy<IDocumentTypesApi> _documentTypesApi;
        private readonly Lazy<IDocumentTypeApi> _documentTypeApi;
        private readonly Lazy<IOrganisationsApi> _organisationsApi;
        private readonly Lazy<IOrganisationApi> _organisationApi;
        private readonly Lazy<IProductsApi> _productsApi;
        private readonly Lazy<IProductApi> _productApi;
        private readonly Lazy<ISubscriptionMembersApi> _subscriptionMembersApi;
        private readonly Lazy<ISubscriptionMetricsApi> _subscriptionMetricsApi;
        private readonly Lazy<ISubscriptionPlanApi> _subscriptionPlanApi;
        private readonly Lazy<ISubscriptionTimeZoneApi> _subscriptionTimeZoneApi;
        private readonly Lazy<IPaymentOptionsApi> _paymentOptionsApi;
        private readonly Lazy<IPaymentOptionApi> _paymentOptionApi;
        private readonly Lazy<ITaxesApi> _taxesApi;
        private readonly Lazy<ITaxApi> _taxApi;
        private readonly Lazy<IInvitationApi> _invitationApi;
        private readonly Lazy<ISubscriptionActivityApi> _subscriptionActivityApi;
        private readonly Lazy<IReportApi> _reportsApi;

        public SubscriptionApi(Func<ClientBase> clientBaseFactory) {
            _clientBase = clientBaseFactory();
            _subscriptionContactApi = new Lazy<ISubscriptionContactApi>(() => new SubscriptionContactApi(_clientBase));
            _subscriptionContactsApi = new Lazy<IContactsApi>(() => new ContactsApi(_clientBase));
            _contactApi = new Lazy<IContactApi>(() => new ContactApi(_clientBase));
            _subscriptionStatusApi = new Lazy<ISubscriptionStatusApi>(() => new SubscriptionStatusApi(_clientBase));
            _subscriptionCompanyApi = new Lazy<ISubscriptionCompanyApi>(() => new SubscriptionCompanyApi(_clientBase));
            _documentsApi = new Lazy<IDocumentsApi>(() => new DocumentsApi(_clientBase));
            _documentApi = new Lazy<IDocumentApi>(() => new DocumentApi(_clientBase));
            _documentTypeApi = new Lazy<IDocumentTypeApi>(() => new DocumentTypeApi(_clientBase));
            _documentTypesApi = new Lazy<IDocumentTypesApi>(() => new DocumentTypesApi(_clientBase));
            _organisationsApi = new Lazy<IOrganisationsApi>(() => new OrganisationsApi(_clientBase));
            _organisationApi = new Lazy<IOrganisationApi>(() => new OrganisationApi(_clientBase));
            _productsApi = new Lazy<IProductsApi>(() => new ProductsApi(_clientBase));
            _productApi = new Lazy<IProductApi>(() => new ProductApi(_clientBase));
            _subscriptionMembersApi = new Lazy<ISubscriptionMembersApi>(() => new SubscriptionMembersApi(_clientBase));
            _subscriptionMetricsApi = new Lazy<ISubscriptionMetricsApi>(() => new SubscriptionMetricsApi(_clientBase));
            _subscriptionPlanApi = new Lazy<ISubscriptionPlanApi>(() => new SubscriptionPlanApi(_clientBase));
            _subscriptionTimeZoneApi = new Lazy<ISubscriptionTimeZoneApi>(() => new SubscriptionTimeZoneApi(_clientBase));
            _paymentOptionsApi = new Lazy<IPaymentOptionsApi>(() => new PaymentOptionsApi(_clientBase));
            _paymentOptionApi = new Lazy<IPaymentOptionApi>(() => new PaymentOptionApi(_clientBase));
            _taxesApi = new Lazy<ITaxesApi>(() => new TaxesApi(_clientBase));
            _taxApi = new Lazy<ITaxApi>(() => new TaxApi(_clientBase));
            _invitationApi = new Lazy<IInvitationApi>(() => new InvitationApi(_clientBase));
            _subscriptionActivityApi = new Lazy<ISubscriptionActivityApi>(() => new SubscriptionActivityApi(_clientBase));
            _reportsApi = new Lazy<IReportApi>(() => new ReportApi(_clientBase));
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

        public IContactApi Contacts(Guid contactId) {
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

        public Task<Subscription> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<Subscription>($"subscriptions/{SubscriptionId}", cancellationToken);

        public IDocumentApi Documents(Guid documentId) {
            var documentApi = _documentApi.Value;
            documentApi.SubscriptionId = SubscriptionId;
            documentApi.DocumentId = documentId.ToString();

            return documentApi;
        }

        public IDocumentsApi Documents() {
            var documentsApi = _documentsApi.Value;
            documentsApi.SubscriptionId = SubscriptionId;

            return documentsApi;
        }

        public IDocumentTypeApi DocumentTypes(Guid documentTypeId) {
            var documentTypeApi = _documentTypeApi.Value;
            documentTypeApi.SubscriptionId = SubscriptionId;
            documentTypeApi.DocumentTypeId = documentTypeId.ToString();

            return documentTypeApi;
        }

        public IDocumentTypesApi DocumentTypes() {
            var documentTypesApi = _documentTypesApi.Value;
            documentTypesApi.SubscriptionId = SubscriptionId;

            return documentTypesApi;
        }

        public ISubscriptionMembersApi Members() {
            var subscriptionMembersApi = _subscriptionMembersApi.Value;
            subscriptionMembersApi.SubscriptionId = SubscriptionId;

            return subscriptionMembersApi;
        }

        public ISubscriptionMetricsApi Metrics() {
            var subscriptionMetricsApi = _subscriptionMetricsApi.Value;
            subscriptionMetricsApi.SubscriptionId = SubscriptionId;

            return subscriptionMetricsApi;
        }

        public IOrganisationApi Organisations(Guid organisationId) {
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

        public ISubscriptionPlanApi Plan() {
            var subscriptionPlanApi = _subscriptionPlanApi.Value;
            subscriptionPlanApi.SubscriptionId = SubscriptionId;

            return subscriptionPlanApi;
        }

        public IProductApi Products(Guid productId) {
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

        public ISubscriptionTimeZoneApi TimeZone() {
            var subscriptionTimeZoneApi = _subscriptionTimeZoneApi.Value;
            subscriptionTimeZoneApi.SubscriptionId = SubscriptionId;

            return subscriptionTimeZoneApi;
        }

        public IPaymentOptionsApi PaymentOptions() {
            var paymentOptionsApi = _paymentOptionsApi.Value;
            paymentOptionsApi.SubscriptionId = SubscriptionId;

            return paymentOptionsApi;
        }

        public IPaymentOptionApi PaymentOptions(Guid paymentOptionId) {
            var paymentOptionApi = _paymentOptionApi.Value;
            paymentOptionApi.SubscriptionId = SubscriptionId;
            paymentOptionApi.PaymentOptionId = paymentOptionId.ToString();

            return paymentOptionApi;
        }

        public ITaxesApi Taxes() {
            var taxesApi = _taxesApi.Value;
            taxesApi.SubscriptionId = SubscriptionId;

            return taxesApi;
        }

        public ITaxApi Taxes(Guid taxId) {
            var taxApi = _taxApi.Value;
            taxApi.SubscriptionId = SubscriptionId;
            taxApi.TaxId = taxId.ToString();

            return taxApi;
        }

        public ISubscriptionActivityApi Activity() {
            var subscriptionActivityApi = _subscriptionActivityApi.Value;
            subscriptionActivityApi.SubscriptionId = SubscriptionId;

            return subscriptionActivityApi;
        }

        public IInvitationApi Invitation() {
            var invitationApi = _invitationApi.Value;
            invitationApi.SubscriptionId = SubscriptionId;

            return invitationApi;
        }

        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken)) => _clientBase.DeleteAsync($"subscriptions/{SubscriptionId}", cancellationToken);

        public IReportApi Reports() {
            var reportApi = _reportsApi.Value;
            reportApi.SubscriptionId = SubscriptionId;

            return reportApi;
        }
    }
}
