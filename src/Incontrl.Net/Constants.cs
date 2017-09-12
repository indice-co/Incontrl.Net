namespace Incontrl.Net
{
    public class Api
    {
        public const string BaseAddress = "http://localhost:20202";
        public const string ResourceName = "core";

        public class EndPoints
        {
            public const string GetSubscriptions = "subscriptions";
            public const string CreateSubscription = "subscriptions";

            /// Parameter corresponds to the subscription id.
            public const string GetSubscriptionById = "subscriptions/{0}";
            public const string GetSubscriptionCompany = "subscriptions/{0}/company";
            public const string GetSubscriptionContact = "subscriptions/{0}/contact";
            public const string GetSubscriptionStatus = "subscriptions/{0}/status";
            public const string UpdateSubscriptionCompany = "subscriptions/{0}/company";
            public const string UpdateSubscriptionStatus = "subscriptions/{0}/status";
        }
    }

    public class IdentityServerConstants
    {
        public const string Authority = "http://localhost:20200";
    }
}