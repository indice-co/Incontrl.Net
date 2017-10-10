using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface ISubscriptionApi
    {
        string SubscriptionId { get; set; }
        Task<Subscription> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        ISubscriptionCompanyApi Company();
        ISubscriptionStatusApi Status();
        IContactsApi Contacts();
        ISubscriptionContactApi Contact();
        IContactApi Contact(Guid contactId);
        IInvoicesApi Invoices();
        IInvoiceApi Invoice(Guid invoiceId);
        IInvoiceTypesApi InvoiceTypes();
        IInvoiceTypeApi InvoiceType(Guid invoiceTypeId);
        IOrganisationsApi Organisations();
        IOrganisationApi Organisation(Guid organisationId);
        IProductsApi Products();
        IProductApi Product(Guid productId);
    }
}
