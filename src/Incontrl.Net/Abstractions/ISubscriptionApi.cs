using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface ISubscriptionApi
    {
        string SubscriptionId { get; set; }

        /// <summary>
        /// Gets a specific subscription by it's unique id or alias.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task<Subscription> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates an instance of class SubscriptionCompanyApi, that provides functionality to retrieve or update a subscription's company information.
        /// </summary>
        ISubscriptionCompanyApi Company();

        /// <summary>
        /// Creates an instance of class SubscriptionStatusApi, that provides functionality to retrieve or update a subscription's status.
        /// </summary>
        ISubscriptionStatusApi Status();

        /// <summary>
        /// Creates an instance of class ContactsApi, that provides functionality to list or create the contacts of the subscription.
        /// </summary>
        IContactsApi Contacts();

        /// <summary>
        /// Creates an instance of class SubscriptionContactApi, that provides functionality to retrieve or update a subscription's contact information.
        /// </summary>
        ISubscriptionContactApi Contact();

        /// <summary>
        /// Creates an instance of class ContactApi, that gives access to a contact's allowed operations.
        /// </summary>
        /// <param name="contactId">The unique id of the contact.</param>
        IContactApi Contact(Guid contactId);

        /// <summary>
        /// Creates an instance of class InvoicesApi, that provides functionality to list or create the invoices of a subscription.
        /// </summary>
        IInvoicesApi Invoices();

        /// <summary>
        /// Creates an instance of class InvoiceApi, that gives access to the allowed operations for invoices.
        /// </summary>
        /// <param name="invoiceId">The unique id of the invoice.</param>
        IInvoiceApi Invoice(Guid invoiceId);

        /// <summary>
        /// Creates an instance of class InvoiceTypesApi, that provides functionality to list or create the invoice types of the subscription.
        /// </summary>
        IInvoiceTypesApi InvoiceTypes();

        /// <summary>
        /// Creates an instance of class InvoiceTypeApi, that gives access to the allowed operations for invoice types.
        /// </summary>
        /// <param name="invoiceTypeId">The unique id of the invoice type.</param>
        IInvoiceTypeApi InvoiceType(Guid invoiceTypeId);

        /// <summary>
        /// Creates an instance of class OrganisationsApi, that provides functionality to list or create organisations for the subscription.
        /// </summary>
        IOrganisationsApi Organisations();

        /// <summary>
        /// Creates an instance of class OrganisationApi, that provides functionality to retrieve or update organisations of the subscription.
        /// </summary>
        /// <param name="organisationId">The unique id of the organisation.</param>
        IOrganisationApi Organisation(Guid organisationId);

        /// <summary>
        /// Creates an instance of class ProductsApi, that provides functionality to list or create the products of the subscription.
        /// </summary>
        IProductsApi Products();

        /// <summary>
        /// Creates an instance of class ProductApi, that provides functionality to retrieve or update products of the subscription.
        /// </summary>
        /// <param name="productId">The unique id of the product.</param>
        IProductApi Product(Guid productId);
    }
}
