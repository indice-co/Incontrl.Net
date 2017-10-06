using System;
using System.Threading.Tasks;
using Incontrl.Net.Models;
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
            var contact = await api.Subscription(subscriptionId)
                                   .Contact()
                                   .GetAsync();

            // Update a subscription's contact.
            contact = await api.Subscription(subscriptionId)
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
        }
    }
}
