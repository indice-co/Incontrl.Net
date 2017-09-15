namespace Incontrl.Net
{
    public class Api
    {
        public const string BaseAddress = "http://localhost:20202";
        public const string ResourceName = "core";
        public const string SubscriptionEndpointsPrefix = "subscriptions";
    }

    public class IdentityServerConstants
    {
        public const string Authority = "http://localhost:20200";
    }

    public static class ValuePresets
    {
        public const string INVOICE_NUMBER_FORMAT = "{0:000000}";
        public const string FALLBACK_CULTURE = "en-US";
        public const string INVOICE_TEMPLATE_FILENAME_NAME = "invoice_template.docx";
    }
}
