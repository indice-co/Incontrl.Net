namespace Incontrl.Net
{
    internal class Api
    {
#if DEBUG
        public const string BASE_ADDRESS = "http://localhost:20202";
#elif RELEASE
        public const string BASE_ADDRESS = "https://api.incontrl.io";
#endif
        public const string RESOURCE_NAME = "core";
        public const string SUBSCRIPTION_ENDPOINTS_PREFIX = "subscriptions";
    }

    internal class IdentityServerConstants
    {
#if DEBUG
        public const string AUTHORITY = "http://localhost:20200";
#elif RELEASE
        public const string AUTHORITY = "https://incontrl.io";
#endif
    }

    internal static class ValuePresets
    {
        public const string INVOICE_NUMBER_FORMAT = "{0:000000}";
        public const string FALLBACK_CULTURE = "en-US";
        public const string INVOICE_TEMPLATE_FILENAME_NAME = "invoice_template.docx";
    }
}
