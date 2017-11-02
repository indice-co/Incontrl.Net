namespace Incontrl.Sdk
{
    internal class Api
    {
#if DEBUG
        public const string CoreApiAddress = "http://localhost:20202";
        public const string AppsApiAddress = "http://localhost:20200/api";
#elif RELEASE
        public const string CoreApiAddress = "https://api.incontrl.io";
        public const string AppsApiAddress = "https://incontrl.io/api";
#endif
    }

    internal class IdentityServerConstants
    {
#if DEBUG
        public const string Authority = "http://localhost:20200";
#elif RELEASE
        public const string Authority = "https://incontrl.io";
#endif
    }
}
