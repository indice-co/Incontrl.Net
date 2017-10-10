using System;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;
using Xunit;

namespace Incontrl.Net.Tests
{
    public class FluentApiTests
    {
        [Fact(Skip = "This is not a test")]
        public async Task SyntaxTest() {
            var api = new IncontrlApi("{my-app-id}", "{my-api-key}");
            var subscriptionId = Guid.NewGuid();
            var subscriptionAlias = "my-subscription";
            var contactId = Guid.NewGuid();
            var invoiceId = Guid.NewGuid();
            var invoiceTypeId = Guid.NewGuid();
            var organisationId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            await api.LoginAsync("{my-username}", "{my-password}");

            #region Subscriptions
            // Get a list of all subscriptions.
            var subscriptions = await api.Subscriptions()
                                         .ListAsync();

            // Create a new subscription.
            var newSubscription = await api.Subscriptions()
                                           .CreateAsync(new CreateSubscriptionRequest { });

            // Get a subscription by id.
            var subscription = await api.Subscription(subscriptionId)
                                        .GetAsync();

            // Get a subscription by alias.
            subscription = await api.Subscription(subscriptionAlias)
                                    .GetAsync();

            // Get a subscription's company.
            var company = await api.Subscription(subscriptionId)
                                   .Company()
                                   .GetAsync();

            // Updates a subscription's company.
            company = await api.Subscription(subscriptionId)
                               .Company()
                               .UpdateAsync(new UpdateCompanyRequest { });

            // Get a subscription's contact.
            var subscriptionContact = await api.Subscription(subscriptionId)
                                               .Contact()
                                               .GetAsync();

            // Update a subscription's contact.
            subscriptionContact = await api.Subscription(subscriptionId)
                                           .Contact()
                                           .UpdateAsync(new UpdateContactRequest { });

            // Get a subscription's status.
            var status = await api.Subscription(subscriptionId)
                                  .Status()
                                  .GetAsync();

            // Update a subscription's status.
            status = await api.Subscription(subscriptionId)
                              .Status()
                              .UpdateAsync(new UpdateSubscriptionStatusRequest { });
            #endregion

            #region Contacts
            var contacts = await api.Subscription(subscriptionId)
                                    .Contacts()
                                    .ListAsync();

            var newContact = await api.Subscription(subscriptionId)
                                      .Contacts()
                                      .CreateAsync(new CreateContactRequest { });

            var contact = await api.Subscription(subscriptionId)
                                   .Contact(contactId)
                                   .GetAsync();

            contact = await api.Subscription(subscriptionId)
                               .Contact(contactId)
                               .UpdateAsync(new UpdateContactRequest { });

            var contactCompanies = await api.Subscription(subscriptionId)
                                            .Contact(contactId)
                                            .Companies()
                                            .GetAsync();
            #endregion

            #region Invoices
            var invoices = await api.Subscription(subscriptionId)
                                        .Invoices()
                                        .ListAsync(new ListOptions<InvoiceListFilter> {
                                            Page = 1,
                                            Size = 25,
                                            Filter = new InvoiceListFilter {
                                                TypeId = Guid.NewGuid()
                                            }
                                        });

            var createdInvoice = await api.Subscription(subscriptionId)
                                          .Invoices()
                                          .CreateAsync(new CreateInvoiceRequest { });

            var invoice = await api.Subscription(subscriptionId)
                                   .Invoice(invoiceId)
                                   .GetAsync();

            invoice = await api.Subscription(subscriptionId)
                               .Invoice(invoiceId)
                               .UpdateAsync(new UpdateInvoiceRequest { });

            await api.Subscription(subscriptionId)
                     .Invoice(invoiceId)
                     .DeleteAsync();

            var invoiceDocument = await api.Subscription(subscriptionId)
                                           .Invoice(invoiceId)
                                           .As(InvoiceFormat.Pdf)
                                           .DownloadAsync();

            var invoiceStatus = await api.Subscription(subscriptionId)
                                         .Invoice(invoiceId)
                                         .Status()
                                         .GetAsync();

            invoiceStatus = await api.Subscription(subscriptionId)
                                     .Invoice(invoiceId)
                                     .Status()
                                     .UpdateAsync(new UpdateInvoiceStatusRequest {
                                         Status = StatusOfInvoice.Void
                                     });

            var invoiceTrackings = await api.Subscription(subscriptionId)
                                            .Invoice(invoiceId)
                                            .Trackings()
                                            .ListAsync();

            var createdInvoiceTracking = await api.Subscription(subscriptionId)
                                                  .Invoice(invoiceId)
                                                  .Trackings()
                                                  .CreateAsync(new CreateInvoiceTrackingRequest {
                                                      Recipient = string.Empty
                                                  });

            var invoiceType = await api.Subscription(subscriptionId)
                                       .Invoice(invoiceId)
                                       .Type()
                                       .GetAsync();

            invoiceType = await api.Subscription(subscriptionId)
                                   .Invoice(invoiceId)
                                   .Type()
                                   .UpdateAsync(new UpdateInvoiceTypeRequest { });
            #endregion

            #region Invoice Types
            var invoiceTypes = await api.Subscription(subscriptionId)
                                            .InvoiceTypes()
                                            .ListAsync();

            var newInvoiceType = await api.Subscription(subscriptionId)
                                          .InvoiceTypes()
                                          .CreateAsync(new CreateInvoiceTypeRequest { });

            var subscriptionInvoiceType = await api.Subscription(subscriptionId)
                                                   .InvoiceType(invoiceTypeId)
                                                   .GetAsync();

            subscriptionInvoiceType = await api.Subscription(subscriptionId)
                                               .InvoiceType(invoiceTypeId)
                                               .UpdateAsync(new UpdateSubscriptionInvoiceTypeRequest { });

            await api.Subscription(subscriptionId)
                     .InvoiceType(invoiceTypeId)
                     .DeleteAsync();

            var invoiceTypeTemplate = await api.Subscription(subscriptionAlias)
                                               .InvoiceType(invoiceTypeId)
                                               .Template()
                                               .DownloadAsync();

            await api.Subscription(subscriptionId)
                     .InvoiceType(invoiceTypeId)
                     .Template()
                     .UploadAsync(new byte[0], string.Empty);
            #endregion

            #region Organisations
            var organisations = await api.Subscription(subscriptionId)
                                             .Organisations()
                                             .ListAsync();

            var newOrganisation = await api.Subscription(subscriptionId)
                                           .Organisations()
                                           .CreateAsync(new CreateOrganisationRequest { });

            var organisation = await api.Subscription(subscriptionId)
                                        .Organisation(organisationId)
                                        .GetAsync();

            organisation = await api.Subscription(subscriptionId)
                                    .Organisation(organisationId)
                                    .UpdateAsync(new UpdateOrganisationRequest { });
            #endregion

            #region Products
            var products = await api.Subscription(subscriptionId)
                                    .Products()
                                    .ListAsync();

            var newProduct = await api.Subscription(subscriptionId)
                                      .Products()
                                      .CreateAsync(new CreateProductRequest { });

            var product = await api.Subscription(subscriptionId)
                                   .Product(productId)
                                   .GetAsync();

            product = await api.Subscription(subscriptionId)
                               .Product(productId)
                               .UpdateAsync(new UpdateProductRequest { }); 
            #endregion
        }
    }
}
