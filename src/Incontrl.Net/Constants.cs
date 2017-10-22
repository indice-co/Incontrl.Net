namespace Incontrl.Net
{
    internal class Api
    {
#if DEBUG
        public const string BASE_ADDRESS = "http://localhost:20202";
#elif RELEASE
        public const string BASE_ADDRESS = "https://api.incontrl.io";
#endif
    }

    internal class IdentityServerConstants
    {
#if DEBUG
        public const string AUTHORITY = "http://localhost:20200";
#elif RELEASE
        public const string AUTHORITY = "https://incontrl.io";
#endif
    }
}
