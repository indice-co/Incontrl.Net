using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Experimental;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class SubscriptionApi : ISubscriptionApi
    {
        private ClientBase _clientBase;
        private Lazy<ISubscriptionContactApi> _subscriptionContactApi;
        private Lazy<IContactsApi> _subscriptionContactsApi;
        private Lazy<IContactApi> _contactApi;
        private Lazy<ISubscriptionStatusApi> _subscriptionStatusApi;
        private Lazy<ISubscriptionCompanyApi> _subscriptionCompanyApi;
        private Lazy<IInvoicesApi> _invoicesApi;
        private Lazy<IInvoiceApi> _invoiceApi;

        public SubscriptionApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _subscriptionContactApi = new Lazy<ISubscriptionContactApi>(() => new SubscriptionContactApi(_clientBase));
            _subscriptionContactsApi = new Lazy<IContactsApi>(() => new ContactsApi(_clientBase));
            _contactApi = new Lazy<IContactApi>(() => new ContactApi(_clientBase));
            _subscriptionStatusApi = new Lazy<ISubscriptionStatusApi>(() => new SubscriptionStatusApi(_clientBase));
            _subscriptionCompanyApi = new Lazy<ISubscriptionCompanyApi>(() => new SubscriptionCompanyApi(_clientBase));
            _invoicesApi = new Lazy<IInvoicesApi>(() => new InvoicesApi(_clientBase));
            _invoiceApi = new Lazy<IInvoiceApi>(() => new InvoiceApi(_clientBase));
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

        public async Task<JsonResponse<Subscription>> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            await _clientBase.GetAsync<Subscription>($"{Api.SUBSCRIPTION_ENDPOINTS_PREFIX}/{SubscriptionId}", cancellationToken);

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

        public ISubscriptionStatusApi Status() {
            var subscriptionStatusApi = _subscriptionStatusApi.Value;
            subscriptionStatusApi.SubscriptionId = SubscriptionId;

            return subscriptionStatusApi;
        }
    }
}
