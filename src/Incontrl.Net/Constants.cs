namespace Incontrl.Net
{
    public class Api
    {
        public const string BASE_ADDRESS = "http://localhost:20202";
        public const string RESOURCE_NAME = "core";
        public const string SUBSCRIPTION_ENDPOINTS_PREFIX = "subscriptions";
    }

    public class IdentityServerConstants
    {
        public const string AUTHORITY = "http://localhost:20200";
    }

    public static class ValuePresets
    {
        public const string INVOICE_NUMBER_FORMAT = "{0:000000}";
        public const string FALLBACK_CULTURE = "en-US";
        public const string INVOICE_TEMPLATE_FILENAME_NAME = "invoice_template.docx";
    }
}
