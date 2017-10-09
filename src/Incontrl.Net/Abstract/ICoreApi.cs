using System;
using System.Threading.Tasks;

namespace Incontrl.Net.Abstract
{
    public interface ICoreApi
    {
        Task LoginAsync(string userName, string password);
        ISubscriptionsApi Subscriptions();
        ISubscriptionApi Subscription(Guid subscriptionId);
        ISubscriptionApi Subscription(string subscriptionAlias);
    }
}
