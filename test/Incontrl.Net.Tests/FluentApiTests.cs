using System;
using System.Threading.Tasks;
using Incontrl.Net.Models;
using Incontrl.Net.Types;
using Xunit;

namespace Incontrl.Net.Tests
{
    public class FluentApiTests
    {
        [Fact]
        public async Task SyntaxTest() {
            var api = new IncontrlApi("{my-app-id}", "{my-api-key}");
            var subscriptionId = Guid.NewGuid();
            var subscriptionAlias = "my-subscription";
            var contactId = Guid.NewGuid();
            var invoiceId = Guid.NewGuid();

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
                                           .Format(InvoiceFormat.Pdf)
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
        }
    }
}
