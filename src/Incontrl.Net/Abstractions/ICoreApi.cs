﻿using System;
using System.Threading.Tasks;

namespace Incontrl.Net.Abstractions
{
    public interface ICoreApi
    {
        Task LoginAsync(string userName, string password);
        Task LoginAsync();
        Task LoginAsync(string refreshToken);
        ISubscriptionsApi Subscriptions();
        ISubscriptionApi Subscription(Guid subscriptionId);
        ISubscriptionApi Subscription(string subscriptionAlias);
        ILicenseApi License();
        ICoreApi Configure(string apiAddress, string authorityAddress = null);
    }
}
