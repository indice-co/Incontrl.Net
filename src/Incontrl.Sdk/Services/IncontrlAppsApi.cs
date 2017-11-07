using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Services;

namespace Incontrl.Sdk
{
    public class IncontrlAppsApi : IClientsApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IAppsApi> _appsApi;
        private readonly Lazy<IAppApi> _appApi;

        public IncontrlAppsApi(string appId, string apiKey, string coreApiAddress = null, string authorityAddress = null, string apiVersion = null) {
            // Optional parameters coreApiAddress and authorityAddress are used to ovveride the production endpoints, so we can use the SDK for development.
            var apiAddress = string.IsNullOrEmpty(coreApiAddress) ? Api.AppsApiAddress : coreApiAddress;
            var authority = string.IsNullOrEmpty(authorityAddress) ? IdentityServerConstants.Authority : authorityAddress;
            _clientBase = new ClientBase(apiVersion == null ? apiAddress : $"{apiAddress}/{apiVersion}", authority, appId, apiKey);
            _appsApi = new Lazy<IAppsApi>(() => new AppsApi(_clientBase));
            _appApi = new Lazy<IAppApi>(() => new AppApi(_clientBase));
        }

        public Uri ApiAddress => _clientBase.ApiAddress;

        public IAppApi App(Guid appId) {
            var appApi = _appApi.Value;
            appApi.AppId = appApi.ToString();

            return appApi;
        }

        public IAppsApi Apps() => _appsApi.Value;

        public Task LoginAsync(string userName, string password, ScopeFlags scopes = ScopeFlags.Apps) => _clientBase.RequestResourceOwnerPasswordAsync(userName, password, scopes);

        public Task LoginAsync(ScopeFlags scopes = ScopeFlags.Apps) => _clientBase.RequestClientCredentialsAsync(scopes);

        public Task LoginAsync(string refreshToken, ScopeFlags scopes = ScopeFlags.Apps) => _clientBase.RequestRefreshTokenAsync(refreshToken, scopes);
    }
}
