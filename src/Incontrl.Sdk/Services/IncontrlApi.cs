using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Http;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Services;

namespace Incontrl.Sdk
{
    /// <summary>
    /// Incontrl's APIs interface.
    /// </summary>
    public sealed class IncontrlApi : ICoreApi
    {
        private readonly Lazy<ISubscriptionsApi> _subscriptionsApi;
        private readonly Lazy<ISubscriptionApi> _subscriptionApi;
        private readonly Lazy<ILicenseApi> _licenseApi;
        private readonly Lazy<IAppsApi> _appsApi;
        private readonly Lazy<IMembersApi> _usersApi;
        private readonly Lazy<IAppApi> _appApi;
        private readonly Lazy<ILookupsApi> _lookupsApi;
        private readonly Uri _baseAddress;
        private readonly Uri _authorityAddress;
        private readonly string _appId;
        private readonly string _apiKey;
        private ClientBase _incontrlApiClientBase;
        private ClientBase _identityApiClientBase;
        private static HttpClient _incontrlApiHttpClient;
        private static HttpClient _incontrlIdentityHttpClient;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="appId">The application id.</param>
        /// <param name="apiKey">The application key.</param>
        /// <param name="baseAddress">Specify this property if you want to override the incontrl's API address. It's intended for testing purposes only.</param>
        /// <param name="authorityAddress">Specify this property if you want to override the authority address of the APIs. It's intended for testing purposes only.</param>
        /// <param name="httpMessageHandler">Optianally specify the <see cref="HttpMessageHandler"/> to be used by the underlying <see cref="HttpClient"/>.</param>
        public IncontrlApi(string appId, string apiKey, Uri baseAddress = null, Uri authorityAddress = null, HttpMessageHandler httpMessageHandler = null) {
            if (string.IsNullOrWhiteSpace(appId)) {
                throw new ArgumentNullException(nameof(appId), "Please specify the application id.");
            }
            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new ArgumentNullException(nameof(apiKey), "Please specify the API key.");
            }
            _appId = appId;
            _apiKey = apiKey;
            // If the developer specifies an alternative base or authority address, then we make use of them. In any other case we use our production endpoints.
            _baseAddress = baseAddress ?? new Uri("https://api.incontrl.io");
            _authorityAddress = authorityAddress ?? new Uri("https://identity.incontrl.io");
            httpMessageHandler ??= new HttpClientHandler();
            _incontrlApiHttpClient ??= new HttpClient(httpMessageHandler) { 
                BaseAddress = _baseAddress 
            }; 
            _incontrlIdentityHttpClient ??= new HttpClient(httpMessageHandler) {
                BaseAddress = _authorityAddress
            };
            // Create one ClientBase (that practically means one HttpClient) per API.
            // This is equivalent to: Func<ClientBase> CreateIncontrlClientBase = () => { };
            ClientBase CreateIncontrlClientBase() {
                if (_incontrlApiClientBase == null) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    _incontrlApiHttpClient.SetBearerToken(AccessToken);
                    _incontrlApiClientBase = new ClientBase(_incontrlApiHttpClient);
                }
                return _incontrlApiClientBase;
            }
            ClientBase CreateIdentityClientBase() {
                if (_identityApiClientBase == null) {
                    
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    _incontrlIdentityHttpClient.SetBearerToken(AccessToken);
                    _identityApiClientBase = new ClientBase(_incontrlIdentityHttpClient);
                }
                return _identityApiClientBase;
            }
            // Interfaces that target Incontrl core API.
            _subscriptionsApi = new Lazy<ISubscriptionsApi>(() => new SubscriptionsApi(CreateIncontrlClientBase));
            _subscriptionApi = new Lazy<ISubscriptionApi>(() => new SubscriptionApi(CreateIncontrlClientBase));
            _licenseApi = new Lazy<ILicenseApi>(() => new LicenseApi(CreateIncontrlClientBase));
            _lookupsApi = new Lazy<ILookupsApi>(() => new LookupsApi(CreateIncontrlClientBase));
            // Interfaces that target Identity API.
            _usersApi = new Lazy<IMembersApi>(() => new UsersApi(CreateIdentityClientBase));
            _appsApi = new Lazy<IAppsApi>(() => new AppsApi(CreateIdentityClientBase));
            _appApi = new Lazy<IAppApi>(() => new AppApi(CreateIdentityClientBase));
        }

        /// <summary>
        /// The access token used to make the call to incontrl API.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Creates an instance of class <see cref="AppsApi"/>, that gives access to a applications's allowed operations.
        /// </summary>
        /// <param name="appId">The application's unique id.</param>
        public IAppApi App(Guid appId) {
            var appApi = _appApi.Value;
            appApi.AppId = appApi.ToString();
            return appApi;
        }

        /// <summary>
        /// Creates an instance of class <see cref="AppsApi"/>, that provides functionality to manage applications.
        /// </summary>
        public IAppsApi Apps() => _appsApi.Value;

        /// <summary>
        /// Creates an instance of class <see cref="UsersApi"/>, that provides functionality to manage users.
        /// </summary>
        public IMembersApi Users() => _usersApi.Value;

        /// <summary>
        /// Creates an instance of class <see cref="LicenseApi"/>, that provides functionality to retrieve InContrl's license information.
        /// </summary>
        public ILicenseApi License() => _licenseApi.Value;

        /// <summary>
        /// Login by using your credentials as a user.
        /// </summary>
        /// <param name="userName">The user's name.</param>
        /// <param name="password">The user's password.</param>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task LoginAsync(string userName, string password, ScopeFlags scopes = ScopeFlags.Core) {
            var discoveryResponse = await _incontrlIdentityHttpClient.GetDiscoveryDocumentAsync();
            var tokenResponse = await _incontrlIdentityHttpClient.RequestPasswordTokenAsync(new PasswordTokenRequest {
                Address = discoveryResponse.TokenEndpoint,
                UserName = userName,
                Password = password,
                ClientId = _appId,
                ClientSecret = _apiKey,
                Scope = scopes.ToScopesText()
            });
            if (tokenResponse.IsError) {
                tokenResponse.HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }
            AccessToken = tokenResponse.AccessToken;
        }

        /// <summary>
        /// Login by using your client credentials.
        /// </summary>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task LoginAsync(ScopeFlags scopes = ScopeFlags.Core) {
            var discoveryResponse = await _incontrlIdentityHttpClient.GetDiscoveryDocumentAsync();
            var tokenResponse = await _incontrlIdentityHttpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest {
                Address = discoveryResponse.TokenEndpoint,
                ClientId = _appId,
                ClientSecret = _apiKey,
                Scope = scopes.ToScopesText()
            });
            if (tokenResponse.IsError) {
                tokenResponse.HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }
            AccessToken = tokenResponse.AccessToken;
        }

        /// <summary>
        /// Login by using a refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token to use.</param>
        /// <param name="scopes">The scopes of the API to request.</param>
        /// <returns>Returns the task object representing the asynchronous operation.</returns>
        public async Task LoginAsync(string refreshToken, ScopeFlags scopes = ScopeFlags.Core) {
            var discoveryResponse = await _incontrlIdentityHttpClient.GetDiscoveryDocumentAsync();
            var tokenResponse = await _incontrlIdentityHttpClient.RequestRefreshTokenAsync(new RefreshTokenRequest {
                Address = discoveryResponse.TokenEndpoint,
                ClientId = _appId,
                ClientSecret = _apiKey,
                Scope = scopes.ToScopesText(),
                RefreshToken = refreshToken
            });
            if (tokenResponse.IsError) {
                tokenResponse.HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }
            AccessToken = tokenResponse.AccessToken;
        }

        /// <summary>
        /// Creates an instance of class <see cref="LookupsApi"/>, that gives access to some of Incontrl lookups.
        /// </summary>
        public ILookupsApi Lookups() => _lookupsApi.Value;

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionApi"/>, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionId">The subscription's unique id.</param>
        public ISubscriptionApi Subscriptions(Guid subscriptionId) => Subscriptions(subscriptionId.ToString());

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionApi"/>, that gives access to a subscription's allowed operations.
        /// </summary>
        /// <param name="subscriptionAlias">The subscription's unique alias.</param>
        public ISubscriptionApi Subscriptions(string subscriptionAlias) {
            var subscriptionApi = _subscriptionApi.Value;
            subscriptionApi.SubscriptionId = subscriptionAlias;
            return subscriptionApi;
        }

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionsApi"/>, that provides functionality to list or create subscriptions.
        /// </summary>
        public ISubscriptionsApi Subscriptions() => _subscriptionsApi.Value;

        /// <summary>
        /// Creates an instance of class <see cref="SubscriptionsApi"/>, that provides functionality to list or create subscriptions.
        /// </summary>
        /// <param name="globalAccess">Request global access for the request.</param>
        public ISubscriptionsApi Subscriptions(bool globalAccess) {
            var subscriptionsApi = _subscriptionsApi.Value;
            subscriptionsApi.GlobalAccess = globalAccess;
            return subscriptionsApi;
        }
    }
}
