using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Services;

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
        /// Permanently deletes a subscription and all related data.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionCompanyApi"/>, that provides functionality to retrieve or update a subscription's company information.
        /// </summary>
        ISubscriptionCompanyApi Company();

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionStatusApi"/>, that provides functionality to retrieve or update a subscription's status.
        /// </summary>
        ISubscriptionStatusApi Status();

        /// <summary>
        /// Creates an instance of class <see cref="ContactsApi"/>, that provides functionality to list or create the contacts of the subscription.
        /// </summary>
        IContactsApi Contacts();

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionContactApi"/>, that provides functionality to retrieve or update a subscription's contact information.
        /// </summary>
        ISubscriptionContactApi Contact();

        /// <summary>
        /// Creates an instance of class <see cref="ContactApi"/>, that gives access to a contact's allowed operations.
        /// </summary>
        /// <param name="contactId">The unique id of the contact.</param>
        IContactApi Contacts(Guid contactId);

        /// <summary>
        /// Creates an instance of class <see cref="DocumentsApi"/>, that provides functionality to list or create the documents of a subscription.
        /// </summary>
        IDocumentsApi Documents();

        /// <summary>
        /// Creates an instance of class <see cref="DocumentsApi"/>, that gives access to the allowed operations for documents.
        /// </summary>
        /// <param name="documentId">The unique id of the document.</param>
        IDocumentApi Documents(Guid documentId);

        /// <summary>
        /// Creates an instance of class <see cref="DocumentTypesApi"/>, that provides functionality to list or create the document types of the subscription.
        /// </summary>
        IDocumentTypesApi DocumentTypes();

        /// <summary>
        /// Creates an instance of class <see cref="DocumentTypeApi"/>, that gives access to the allowed operations for document types.
        /// </summary>
        /// <param name="documentTypeId">The unique id of the document type.</param>
        IDocumentTypeApi DocumentTypes(Guid documentTypeId);

        /// <summary>
        /// Creates an instance of class <see cref="OrganisationsApi"/>, that provides functionality to list or create organisations for the subscription.
        /// </summary>
        IOrganisationsApi Organisations();

        /// <summary>
        /// Creates an instance of class <see cref="OrganisationApi"/>, that provides functionality to retrieve or update organisations of the subscription.
        /// </summary>
        /// <param name="organisationId">The unique id of the organisation.</param>
        IOrganisationApi Organisations(Guid organisationId);

        /// <summary>
        /// Creates an instance of class <see cref="ProductsApi"/>, that provides functionality to list or create the products of the subscription.
        /// </summary>
        IProductsApi Products();

        /// <summary>
        /// Creates an instance of class ProductApi, that provides functionality to retrieve or update products of the subscription.
        /// </summary>
        /// <param name="productId">The unique id of the product.</param>
        IProductApi Products(Guid productId);

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
        /// <param name="paymentOptionId"></param>
        /// <returns></returns>
        IPaymentOptionApi PaymentOptions(Guid paymentOptionId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ITaxesApi Taxes();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxId"></param>
        /// <returns></returns>
        ITaxApi Taxes(Guid taxId);

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionActivity"/>, that provides functionality to retrieve the activity of the subscription.
        /// </summary>
        ISubscriptionActivityApi Activity();

        /// <summary>
        /// Creates an instance of class <see cref="InvitationApi"/>, that provides functionality to send and accept invitations.
        /// </summary>
        /// <returns></returns>
        IInvitationApi Invitation();
    }
}
