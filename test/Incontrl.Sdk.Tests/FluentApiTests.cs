using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;
using Xunit;

namespace Incontrl.Sdk.Tests
{
    public class FluentApiTests
    {
        [Fact(Skip = "This is not an actual test")]
        public async Task SyntaxTest() {
            var api = new IncontrlApi("{my-app-id}", "{my-api-key}");
            var subscriptionId = Guid.NewGuid();
            var subscriptionAlias = "my-subscription";
            var contactId = Guid.NewGuid();
            var documentId = Guid.NewGuid();
            var documentTypeId = Guid.NewGuid();
            var organisationId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var bankAccountId = Guid.NewGuid();
            var transactionId = Guid.NewGuid();
            var paymentOptionId = Guid.NewGuid();
            await api.LoginAsync("{my-username}", "{my-password}");

            #region Subscriptions
            // GET: /subscriptions
            var subscriptions = await api.Subscriptions()
                                         .ListAsync();

            // POST: /subscriptions
            var newSubscription = await api.Subscriptions()
                                           .CreateAsync(new CreateSubscriptionRequest { });

            // GET: /subscriptions/{subscriptionId}
            var subscription = await api.Subscription(subscriptionId)
                                        .GetAsync();

            // GET: /subscriptions/{subscriptionId}
            subscription = await api.Subscription(subscriptionAlias)
                                    .GetAsync();

            // GET: /subscriptions/{subscriptionId}/company
            var company = await api.Subscription(subscriptionId)
                                   .Company()
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/company
            company = await api.Subscription(subscriptionId)
                               .Company()
                               .UpdateAsync(new UpdateCompanyRequest { });

            // GET: /subscriptions/{subscriptionId}/contact
            var subscriptionContact = await api.Subscription(subscriptionId)
                                               .Contact()
                                               .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/contact
            subscriptionContact = await api.Subscription(subscriptionId)
                                           .Contact()
                                           .UpdateAsync(new UpdateContactRequest { });

            // GET: /subscriptions/{subscriptionId}/members
            var subscriptionMembers = await api.Subscription(subscriptionId)
                                               .Members()
                                               .ListAsync();

            // GET: /subscriptions/{subscriptionId}/metrics
            var subscriptionMetrics = await api.Subscription(subscriptionId)
                                               .Metrics()
                                               .ListAsync();

            // GET: /subscriptions/{subscriptionId}/plan
            var subscriptionPlan = await api.Subscription(subscriptionId)
                                            .Plan()
                                            .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/plan
            await api.Subscription(subscriptionId)
                     .Plan()
                     .UpdateAsync(new Plan { });

            // GET: /subscriptions/{subscriptionId}/status
            var status = await api.Subscription(subscriptionId)
                                  .Status()
                                  .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/status
            status = await api.Subscription(subscriptionId)
                              .Status()
                              .UpdateAsync(new SubscriptionStatus { });

            // PUT: /subscriptions/{subscriptionId}/time-zone
            subscription = await api.Subscription(subscriptionId)
                                    .TimeZone()
                                    .UpdateAsync(new UpdateSubscriptionTimeZoneRequest { });

            // GET: /subscriptions/all
            var allSubscriptions = await api.Subscriptions(globalAccess: true)
                                            .ListAsync();

            // GET: /subscriptions/all/metrics
            var metrics = await api.Subscriptions()
                                   .Metrics()
                                   .ListAsync();
            #endregion

            #region Contacts
            // GET: /subscriptions/{subscriptionId}/contacts
            var contacts = await api.Subscription(subscriptionId)
                                    .Contacts()
                                    .ListAsync();

            // POST: /subscriptions/{subscriptionId}/contacts
            var newContact = await api.Subscription(subscriptionId)
                                      .Contacts()
                                      .CreateAsync(new CreateContactRequest { });

            // GET: /subscriptions/{subscriptionId}/contacts/{contactId}
            var contact = await api.Subscription(subscriptionId)
                                   .Contact(contactId)
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/contacts/{contactId}
            contact = await api.Subscription(subscriptionId)
                               .Contact(contactId)
                               .UpdateAsync(new UpdateContactRequest { });

            // GET: /subscriptions/{subscriptionId}/contacts/{contactId}/companies
            var contactCompanies = await api.Subscription(subscriptionId)
                                            .Contact(contactId)
                                            .Companies()
                                            .GetAsync();
            #endregion

            #region Documents
            // GET: /subscriptions/{subscriptionId}/documents
            var documents = await api.Subscription(subscriptionId)
                                     .Documents()
                                     .ListAsync(new ListOptions<DocumentListFilter> {
                                         Page = 1,
                                         Size = 25,
                                         Filter = new DocumentListFilter {
                                             TypeId = Guid.NewGuid(),
                                             PaymentCode = string.Empty
                                         }
                                     });

            // POST: /subscriptions/{subscriptionId}/documents
            var createdDocument = await api.Subscription(subscriptionId)
                                           .Documents()
                                           .CreateAsync(new CreateDocumentRequest { });

            // DELETE: /subscriptions/{subscriptionId}/documents/{documentId}
            await api.Subscription(subscriptionId)
                     .Document(documentId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}
            var document = await api.Subscription(subscriptionId)
                                   .Document(documentId)
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/documents/{documentId}
            document = await api.Subscription(subscriptionId)
                                .Document(documentId)
                                .UpdateAsync(new UpdateDocumentRequest { });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/payments
            var documentPayments = await api.Subscription(subscriptionId)
                                            .Document(documentId)
                                            .Payments()
                                            .ListAsync();

            // POST: /subscriptions/{subscriptionId}/documents/{documentId}/payments
            var newDocumentPayment = await api.Subscription(subscriptionId)
                                              .Document(documentId)
                                              .Payments()
                                              .CreateAsync(new Payment { });

            // DELETE: /subscriptions/{subscriptionId}/documents/{documentId}/payments/{transactionId}
            await api.Subscription(subscriptionId)
                     .Document(documentId)
                     .Payments()
                     .Transaction(transactionId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/payments/{transactionId}/approval
            await api.Subscription(subscriptionId)
                     .Document(documentId)
                     .Payments()
                     .Transaction(transactionId)
                     .Approval()
                     .UpdateAsync(new UpdateApprovalRequest { });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/status
            var documentStatus = await api.Subscription(subscriptionId)
                                          .Document(documentId)
                                          .Status()
                                          .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/documents/{documentId}/status
            documentStatus = await api.Subscription(subscriptionId)
                                      .Document(documentId)
                                      .Status()
                                      .UpdateAsync(new DocumentStatus { });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/trackings
            var documentTrackings = await api.Subscription(subscriptionId)
                                             .Document(documentId)
                                             .Trackings()
                                             .ListAsync();

            // POST: /subscriptions/{subscriptionId}/documents/{documentId}/trackings
            var createdDocumentTracking = await api.Subscription(subscriptionId)
                                                   .Document(documentId)
                                                   .Trackings()
                                                   .CreateAsync(new CreateDocumentTrackingRequest {
                                                       Recipient = string.Empty
                                                   });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/type
            var documentType = await api.Subscription(subscriptionId)
                                        .Document(documentId)
                                        .Type()
                                        .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/documents/{documentId}/type
            documentType = await api.Subscription(subscriptionId)
                                    .Document(documentId)
                                    .Type()
                                    .UpdateAsync(new UpdateDocumentTypeRequest { });

            // GET: documents/{documentId}.{format?}
            var documentDocument = await api.Subscription(subscriptionId)
                                            .Document(documentId)
                                            .As(DocumentFormat.Pdf)
                                            .DownloadAsync();
            #endregion

            #region Document Types
            // GET: /subscriptions/{subscriptionId}/document-types
            var documentTypes = await api.Subscription(subscriptionId)
                                         .DocumentTypes()
                                         .ListAsync();

            // POST: /subscriptions/{subscriptionId}/document-types
            var newDocumentType = await api.Subscription(subscriptionId)
                                           .DocumentTypes()
                                           .CreateAsync(new CreateDocumentTypeRequest { });

            // DELETE: /subscriptions/{subscriptionId}/document-types/{documentTypeId}
            await api.Subscription(subscriptionId)
                     .DocumentType(documentTypeId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/document-types/{documentTypeId}
            var subscriptionDocumentType = await api.Subscription(subscriptionId)
                                                    .DocumentType(documentTypeId)
                                                    .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/document-types/{documentTypeId}
            subscriptionDocumentType = await api.Subscription(subscriptionId)
                                                .DocumentType(documentTypeId)
                                                .UpdateAsync(new UpdateDocumentTypeRequest { });

            // GET: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/payment-options
            var documentTypePaymentOptions = await api.Subscription(subscriptionId)
                                                      .DocumentType(documentTypeId)
                                                      .PaymentOptions()
                                                      .ListAsync();

            // POST: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/payment-options
            var createdDocumentTypePaymentOption = await api.Subscription(subscriptionId)
                                                            .DocumentType(documentTypeId)
                                                            .PaymentOptions()
                                                            .CreateAsync(new PaymentOption { });

            // DELETE: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/payment-options/{paymentOptionId}
            await api.Subscription(subscriptionId)
                     .DocumentType(documentId)
                     .PaymentOption(paymentOptionId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/template
            var documentTypeTemplate = await api.Subscription(subscriptionAlias)
                                                .DocumentType(documentTypeId)
                                                .Template()
                                                .DownloadAsync();

            // POST: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/template
            await api.Subscription(subscriptionId)
                     .DocumentType(documentTypeId)
                     .Template()
                     .UploadAsync(new byte[0], string.Empty);
            #endregion

            #region Organisations
            // GET: /subscriptions/{subscriptionId}/organisations
            var organisations = await api.Subscription(subscriptionId)
                                         .Organisations()
                                         .ListAsync();

            // POST: /subscriptions/{subscriptionId}/organisations
            var newOrganisation = await api.Subscription(subscriptionId)
                                           .Organisations()
                                           .CreateAsync(new CreateOrganisationRequest { });

            // GET: /subscriptions/{subscriptionId}/organisations/{organisationId}
            var organisation = await api.Subscription(subscriptionId)
                                        .Organisation(organisationId)
                                        .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/organisations/{organisationId}
            organisation = await api.Subscription(subscriptionId)
                                    .Organisation(organisationId)
                                    .UpdateAsync(new UpdateOrganisationRequest { });
            #endregion

            #region Products
            // GET: /subscriptions/{subscriptionId}/products
            var products = await api.Subscription(subscriptionId)
                                    .Products()
                                    .ListAsync();

            // POST: /subscriptions/{subscriptionId}/products
            var newProduct = await api.Subscription(subscriptionId)
                                      .Products()
                                      .CreateAsync(new CreateProductRequest { });

            // GET: /subscriptions/{subscriptionId}/products/{productId}
            var product = await api.Subscription(subscriptionId)
                                   .Product(productId)
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/products/{productId}
            product = await api.Subscription(subscriptionId)
                               .Product(productId)
                               .UpdateAsync(new UpdateProductRequest { });
            #endregion

            #region Payment Options
            // GET: /subscriptions/{subscriptionId}/payment-options
            var paymentOptions = await api.Subscription(subscriptionId)
                                          .PaymentOptions()
                                          .ListAsync();

            // POST: /subscriptions/{subscriptionId}/payment-options
            var createdPaymentOption = await api.Subscription(subscriptionId)
                                                .PaymentOptions()
                                                .CreateAsync(new PaymentOption { });

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}
            var paymentOption = await api.Subscription(subscriptionId)
                                         .PaymentOption(paymentOptionId)
                                         .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}
            paymentOption = await api.Subscription(subscriptionId)
                                     .PaymentOption(paymentOptionId)
                                     .UpdateAsync(new PaymentOption { });

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions
            var transactions = await api.Subscription(subscriptionId)
                                        .PaymentOption(paymentOptionId)
                                        .Transactions()
                                        .ListAsync();

            // POST: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions
            var createdTransaction = await api.Subscription(subscriptionId)
                                              .PaymentOption(paymentOptionId)
                                              .Transactions()
                                              .CreateAsync(new Transaction { });

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/{transactionId}
            var transaction = await api.Subscription(subscriptionId)
                                       .PaymentOption(paymentOptionId)
                                       .Transaction(transactionId)
                                       .GetAsync();

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/{transactionId}/payments
            var payments = await api.Subscription(subscriptionId)
                                    .PaymentOption(paymentOptionId)
                                    .Transaction(transactionId)
                                    .Payments()
                                    .ListAsync();

            // POST: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/{transactionId}/payments
            var createdPayment = await api.Subscription(subscriptionId)
                                          .PaymentOption(paymentOptionId)
                                          .Transaction(transactionId)
                                          .Payments()
                                          .CreateAsync(new Payment { });

            // POST: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/bulk
            await api.Subscription(subscriptionId)
                     .PaymentOption(paymentOptionId)
                     .Transactions()
                     .BulkCreateAsync(new BulkLoadTransactionsRequest { });
            #endregion
        }
    }
}
