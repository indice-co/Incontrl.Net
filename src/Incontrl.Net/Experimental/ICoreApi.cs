using System;
using System.Collections.Generic;
using System.Text;

namespace Incontrl.Net.Experimental
{
   

    public interface ICoreApi
    {
        ISubscriptionsApi Subscriptions();
        ISubscriptionApi Subscriptions(Guid subscriptionId);
        ISubscriptionApi Subscriptions(string subscriptionAlias);
    }
}
