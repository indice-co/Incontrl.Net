using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubscriptionApi
    {
        /// <summary>
        /// 
        /// </summary>
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
        /// Creates an instance of class DocumentsApi, that provides functionality to list or create the documents of a subscription.
        /// </summary>
        IDocumentsApi Documents();

        /// <summary>
        /// Creates an instance of class DocumentsApi, that gives access to the allowed operations for documents.
        /// </summary>
        /// <param name="documentId">The unique id of the document.</param>
        IDocumentApi Document(Guid documentId);

        /// <summary>
        /// Creates an instance of class DocumentTypesApi, that provides functionality to list or create the document types of the subscription.
        /// </summary>
        IDocumentTypesApi DocumentTypes();

        /// <summary>
        /// Creates an instance of class DocumentTypeApi, that gives access to the allowed operations for document types.
        /// </summary>
        /// <param name="documentTypeId">The unique id of the document type.</param>
        IDocumentTypeApi DocumentType(Guid documentTypeId);

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubscriptionMembersApi Members();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubscriptionMetricsApi Metrics();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubscriptionPlanApi Plan();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubscriptionTimeZoneApi TimeZone();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IPaymentOptionsApi PaymentOptions();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IPaymentOptionApi PaymentOption(Guid paymentOptionId);
    }
}
