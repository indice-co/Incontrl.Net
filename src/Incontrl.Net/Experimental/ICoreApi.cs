using System;

namespace Incontrl.Net.Experimental
{
    public interface ICoreApi
    {
        ISubscriptionsApi Subscriptions();
        ISubscriptionApi Subscription(Guid subscriptionId);
        ISubscriptionApi Subscription(string subscriptionAlias);
    }
}
