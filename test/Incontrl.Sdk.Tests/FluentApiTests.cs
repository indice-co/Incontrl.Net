using System;
using System.IO;
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
            var appId = Guid.NewGuid();
            var taxId = Guid.NewGuid();
            await api.LoginAsync("{my-username}", "{my-password}");

            #region Subscriptions
            // GET: /subscriptions
            var subscriptions = await api.Subscriptions()
                                         .ListAsync();

            // POST: /subscriptions
            var newSubscription = await api.Subscriptions()
                                           .CreateAsync(new CreateSubscriptionRequest { });

            // GET: /subscriptions/{subscriptionId}
            var subscription = await api.Subscriptions(subscriptionId)
                                        .GetAsync();

            // GET: /subscriptions/{subscriptionId}
            subscription = await api.Subscriptions(subscriptionAlias)
                                    .GetAsync();

            // GET: /subscriptions/{subscriptionId}/company
            var company = await api.Subscriptions(subscriptionId)
                                   .Company()
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/company
            company = await api.Subscriptions(subscriptionId)
                               .Company()
                               .UpdateAsync(new UpdateCompanyRequest { });

            // GET: /subscriptions/{subscriptionId}/contact
            var subscriptionContact = await api.Subscriptions(subscriptionId)
                                               .Contact()
                                               .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/contact
            subscriptionContact = await api.Subscriptions(subscriptionId)
                                           .Contact()
                                           .UpdateAsync(new Contact());

            // GET: /subscriptions/{subscriptionId}/members
            var subscriptionMembers = await api.Subscriptions(subscriptionId)
                                               .Members()
                                               .ListAsync();

            // GET: /subscriptions/{subscriptionId}/metrics
            var subscriptionMetrics = await api.Subscriptions(subscriptionId)
                                               .Metrics()
                                               .ListAsync();

            // GET: /subscriptions/{subscriptionId}/plan
            var subscriptionPlan = await api.Subscriptions(subscriptionId)
                                            .Plan()
                                            .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/plan
            await api.Subscriptions(subscriptionId)
                     .Plan()
                     .UpdateAsync(new Plan { });

            // GET: /subscriptions/{subscriptionId}/status
            var status = await api.Subscriptions(subscriptionId)
                                  .Status()
                                  .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/status
            status = await api.Subscriptions(subscriptionId)
                              .Status()
                              .UpdateAsync(new SubscriptionStatus { });

            // PUT: /subscriptions/{subscriptionId}/time-zone
            subscription = await api.Subscriptions(subscriptionId)
                                    .TimeZone()
                                    .UpdateAsync(new UpdateSubscriptionTimeZoneRequest { });

            // GET: /subscriptions/all
            var allSubscriptions = await api.Subscriptions(globalAccess: true)
                                            .ListAsync();

            // GET: /subscriptions/all/metrics
            var metrics = await api.Subscriptions()
                                   .Metrics()
                                   .ListAsync();

            // GET: /subscriptions/{subscriptionId}/activity
            var activity = await api.Subscriptions(subscriptionId)
                                    .Activity()
                                    .GetAsync();

            // GET: /subscriptions/activity
            var overallActivity = await api.Subscriptions().ListAsync();

            // POST: /subscriptions/{subscriptionId}/invite
            var invitation = await api.Subscriptions(subscriptionId)
                                      .Invitation()
                                      .SendAsync("g.manoltzas@indice.gr");

            // POST: /subscriptions/{subscriptionId}/accept-invitation
            await api.Subscriptions()
                     .Invitation("invitationId")
                     .AcceptAsync("memberId");
            #endregion

            #region Contacts
            // GET: /subscriptions/{subscriptionId}/contacts
            var contacts = await api.Subscriptions(subscriptionId)
                                    .Contacts()
                                    .ListAsync();

            // POST: /subscriptions/{subscriptionId}/contacts
            var newContact = await api.Subscriptions(subscriptionId)
                                      .Contacts()
                                      .CreateAsync(new Contact { });

            // GET: /subscriptions/{subscriptionId}/contacts/{contactId}
            var contact = await api.Subscriptions(subscriptionId)
                                   .Contacts(contactId)
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/contacts/{contactId}
            contact = await api.Subscriptions(subscriptionId)
                               .Contacts(contactId)
                               .UpdateAsync(new Contact());

            // GET: /subscriptions/{subscriptionId}/contacts/{contactId}/companies
            var contactCompanies = await api.Subscriptions(subscriptionId)
                                            .Contacts(contactId)
                                            .Companies()
                                            .ListAsync();
            #endregion

            #region Documents
            // GET: /subscriptions/{subscriptionId}/documents
            var documents = await api.Subscriptions(subscriptionId)
                                     .Documents()
                                     .ListAsync(new ListOptions<DocumentListFilter> {
                                         Page = 1,
                                         Size = 25,
                                         Filter = new DocumentListFilter {
                                             TypeId = new[] {
                                                 Guid.NewGuid()
                                             },
                                             PaymentCode = string.Empty
                                         }
                                     });

            // POST: /subscriptions/{subscriptionId}/documents
            var createdDocument = await api.Subscriptions(subscriptionId)
                                           .Documents()
                                           .CreateAsync(new CreateDocumentRequest { });

            // DELETE: /subscriptions/{subscriptionId}/documents/{documentId}
            await api.Subscriptions(subscriptionId)
                     .Documents(documentId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}
            var document = await api.Subscriptions(subscriptionId)
                                   .Documents(documentId)
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/documents/{documentId}
            document = await api.Subscriptions(subscriptionId)
                                .Documents(documentId)
                                .UpdateAsync(new UpdateDocumentRequest { });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/payments
            var documentPayments = await api.Subscriptions(subscriptionId)
                                            .Documents(documentId)
                                            .Payments()
                                            .ListAsync();

            // POST: /subscriptions/{subscriptionId}/documents/{documentId}/payments
            var newDocumentPayment = await api.Subscriptions(subscriptionId)
                                              .Documents(documentId)
                                              .Payments()
                                              .CreateAsync(new Payment { });

            // DELETE: /subscriptions/{subscriptionId}/documents/{documentId}/payments/{transactionId}
            await api.Subscriptions(subscriptionId)
                     .Documents(documentId)
                     .Payments()
                     .Transactions(transactionId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/payments/{transactionId}/approval
            await api.Subscriptions(subscriptionId)
                     .Documents(documentId)
                     .Payments()
                     .Transactions(transactionId)
                     .Approval()
                     .UpdateAsync(new UpdateApprovalRequest { });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/status
            var documentStatus = await api.Subscriptions(subscriptionId)
                                          .Documents(documentId)
                                          .Status()
                                          .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/documents/{documentId}/status
            documentStatus = await api.Subscriptions(subscriptionId)
                                      .Documents(documentId)
                                      .Status()
                                      .UpdateAsync(new UpdateDocumentStatusRequest { });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/trackings
            var documentTrackings = await api.Subscriptions(subscriptionId)
                                             .Documents(documentId)
                                             .Trackings()
                                             .ListAsync();

            // POST: /subscriptions/{subscriptionId}/documents/{documentId}/trackings
            var createdDocumentTracking = await api.Subscriptions(subscriptionId)
                                                   .Documents(documentId)
                                                   .Trackings()
                                                   .CreateAsync(new CreateDocumentTrackingRequest {
                                                       Recipient = string.Empty
                                                   });

            // GET: /subscriptions/{subscriptionId}/documents/{documentId}/type
            var documentType = await api.Subscriptions(subscriptionId)
                                        .Documents(documentId)
                                        .Type()
                                        .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/documents/{documentId}/type
            documentType = await api.Subscriptions(subscriptionId)
                                    .Documents(documentId)
                                    .Type()
                                    .UpdateAsync(new UpdateDocumentDocumentType {
                                        TypeId = Guid.NewGuid()
                                    });

            // GET: documents/{documentId}.{format?}
            var documentDocument = await api.Subscriptions(subscriptionId)
                                            .Documents(documentId)
                                            .As(DocumentFormat.Pdf)
                                            .DownloadAsync();
            #endregion

            #region Document Types
            // GET: /subscriptions/{subscriptionId}/document-types
            var documentTypes = await api.Subscriptions(subscriptionId)
                                         .DocumentTypes()
                                         .ListAsync();

            // POST: /subscriptions/{subscriptionId}/document-types
            var newDocumentType = await api.Subscriptions(subscriptionId)
                                           .DocumentTypes()
                                           .CreateAsync(new CreateDocumentTypeRequest { });

            // DELETE: /subscriptions/{subscriptionId}/document-types/{documentTypeId}
            await api.Subscriptions(subscriptionId)
                     .DocumentTypes(documentTypeId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/document-types/{documentTypeId}
            var subscriptionDocumentType = await api.Subscriptions(subscriptionId)
                                                    .DocumentTypes(documentTypeId)
                                                    .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/document-types/{documentTypeId}
            subscriptionDocumentType = await api.Subscriptions(subscriptionId)
                                                .DocumentTypes(documentTypeId)
                                                .UpdateAsync(new UpdateDocumentTypeRequest { });

            // GET: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/payment-options
            var documentTypePaymentOptions = await api.Subscriptions(subscriptionId)
                                                      .DocumentTypes(documentTypeId)
                                                      .PaymentOptions()
                                                      .ListAsync();

            // POST: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/payment-options
            var createdDocumentTypePaymentOption = await api.Subscriptions(subscriptionId)
                                                            .DocumentTypes(documentTypeId)
                                                            .PaymentOptions()
                                                            .CreateAsync(new PaymentOption { });

            // DELETE: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/payment-options/{paymentOptionId}
            await api.Subscriptions(subscriptionId)
                     .DocumentTypes(documentId)
                     .PaymentOptions(paymentOptionId)
                     .DeleteAsync();

            // GET: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/template
            var documentTypeTemplate = await api.Subscriptions(subscriptionAlias)
                                                .DocumentTypes(documentTypeId)
                                                .Template()
                                                .DownloadAsync();

            // POST: /subscriptions/{subscriptionId}/document-types/{documentTypeId}/template
            await api.Subscriptions(subscriptionId)
                     .DocumentTypes(documentTypeId)
                     .Template()
                     .UploadAsync(File.OpenRead(""), string.Empty);
            #endregion

            #region Organisations
            // GET: /subscriptions/{subscriptionId}/organisations
            var organisations = await api.Subscriptions(subscriptionId)
                                         .Organisations()
                                         .ListAsync();

            // POST: /subscriptions/{subscriptionId}/organisations
            var newOrganisation = await api.Subscriptions(subscriptionId)
                                           .Organisations()
                                           .CreateAsync(new Organisation { });

            // GET: /subscriptions/{subscriptionId}/organisations/{organisationId}
            var organisation = await api.Subscriptions(subscriptionId)
                                        .Organisations(organisationId)
                                        .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/organisations/{organisationId}
            organisation = await api.Subscriptions(subscriptionId)
                                    .Organisations(organisationId)
                                    .UpdateAsync(new UpdateOrganisationRequest { });
            #endregion

            #region Products
            // GET: /subscriptions/{subscriptionId}/products
            var products = await api.Subscriptions(subscriptionId)
                                    .Products()
                                    .ListAsync();

            // POST: /subscriptions/{subscriptionId}/products
            var newProduct = await api.Subscriptions(subscriptionId)
                                      .Products()
                                      .CreateAsync(new Product { });

            // GET: /subscriptions/{subscriptionId}/products/{productId}
            var product = await api.Subscriptions(subscriptionId)
                                   .Products(productId)
                                   .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/products/{productId}
            product = await api.Subscriptions(subscriptionId)
                               .Products(productId)
                               .UpdateAsync(new Product { });
            #endregion

            #region Payment Options
            // GET: /subscriptions/{subscriptionId}/payment-options
            var paymentOptions = await api.Subscriptions(subscriptionId)
                                          .PaymentOptions()
                                          .ListAsync();

            // POST: /subscriptions/{subscriptionId}/payment-options
            var createdPaymentOption = await api.Subscriptions(subscriptionId)
                                                .PaymentOptions()
                                                .CreateAsync(new PaymentOption { });

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}
            var paymentOption = await api.Subscriptions(subscriptionId)
                                         .PaymentOptions(paymentOptionId)
                                         .GetAsync();

            // PUT: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}
            paymentOption = await api.Subscriptions(subscriptionId)
                                     .PaymentOptions(paymentOptionId)
                                     .UpdateAsync(new PaymentOption { });

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions
            var transactions = await api.Subscriptions(subscriptionId)
                                        .PaymentOptions(paymentOptionId)
                                        .Transactions()
                                        .ListAsync();

            // POST: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions
            var createdTransaction = await api.Subscriptions(subscriptionId)
                                              .PaymentOptions(paymentOptionId)
                                              .Transactions()
                                              .CreateAsync(new Transaction { });

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/{transactionId}
            var transaction = await api.Subscriptions(subscriptionId)
                                       .PaymentOptions(paymentOptionId)
                                       .Transactions(transactionId)
                                       .GetAsync();

            // GET: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/{transactionId}/payments
            var payments = await api.Subscriptions(subscriptionId)
                                    .PaymentOptions(paymentOptionId)
                                    .Transactions(transactionId)
                                    .Payments()
                                    .ListAsync();

            // POST: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/{transactionId}/payments
            var createdPayment = await api.Subscriptions(subscriptionId)
                                          .PaymentOptions(paymentOptionId)
                                          .Transactions(transactionId)
                                          .Payments()
                                          .CreateAsync(new Payment { });

            // POST: /subscriptions/{subscriptionId}/payment-options/{paymentOptionId}/transactions/bulk
            await api.Subscriptions(subscriptionId)
                     .PaymentOptions(paymentOptionId)
                     .Transactions()
                     .BulkCreateAsync(new BulkLoadTransactionsRequest { });
            #endregion

            #region Apps / Users
            // GET: api/apps
            var myApps = await api.Apps()
                                  .ListAsync();

            // GET: api/apps/{appId}
            var app = await api.App(appId)
                               .GetAsync();

            //GET: api/apps/all/webhooks
            var webHooks = await api.Apps()
                                    .WebHooks()
                                    .ListAsync();

            //GET: api/apps/members
            var members = await api.Apps()
                                   .Members()
                                   .ListAsync(new MemberRequest());

            var users = await api.Users()
                                 .ListAsync(new MemberRequest());
            #endregion

            #region Lookups
            var timezones = await api.Lookups()
                                     .TimeZones()
                                     .ListAsync(new ListOptions {
                                         Page = 1,
                                         Size = 100
                                     });
            #endregion

            #region Taxes
            var taxes = await api.Subscriptions(subscriptionId)
                                 .Taxes()
                                 .ListAsync();

            var newTax = await api.Subscriptions(subscriptionId)
                                  .Taxes()
                                  .CreateAsync(new TaxDefinition());

            var tax = await api.Subscriptions(subscriptionId)
                               .Taxes(taxId)
                               .GetAsync();

            var updatedTax = api.Subscriptions(subscriptionId)
                                .Taxes(taxId)
                                .UpdateAsync(new TaxDefinition());

            await api.Subscriptions(subscriptionId)
                     .Taxes(taxId)
                     .DeleteAsync();
            #endregion

            #region Email
            await api.Email().SendAsync(new EmailRequest {
                Recipients = new string[] { "g.manoltzas@indice.gr" },
                Subject = "Welcome",
                 Body = "<h1>Hello World!</h1>"
            });
            #endregion
        }
    }
}
