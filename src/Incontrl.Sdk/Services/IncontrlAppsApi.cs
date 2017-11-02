using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    public class IncontrlAppsApi : IClientsApi
    {
        private readonly ClientBase _clientBase;

        public IncontrlAppsApi(string appId, string apiKey, string apiVersion = null) {
            _clientBase = new ClientBase(apiVersion == null ? Api.CoreApiAddress : $"{Api.CoreApiAddress}/{apiVersion}", appId, apiKey);
        }

        public Uri ApiAddress => _clientBase.ApiAddress;

        public IAppsApi Apps() {
            throw new NotImplementedException();
        }

        public IClientsApi Configure(string apiAddress, string authorityAddress = null) {
            _clientBase.ApiAddress = new Uri(apiAddress);

            if (authorityAddress != null) {
                _clientBase.AuthorityAddress = new Uri(authorityAddress);
            }

            return this;
        }

        public Task LoginAsync(string userName, string password, ScopeFlags scopes = ScopeFlags.Apps) => _clientBase.RequestResourceOwnerPasswordAsync(userName, password, scopes);

        public Task LoginAsync(ScopeFlags scopes = ScopeFlags.Apps) => _clientBase.RequestClientCredentialsAsync(scopes);

        public Task LoginAsync(string refreshToken, ScopeFlags scopes = ScopeFlags.Apps) => _clientBase.RequestRefreshTokenAsync(refreshToken, scopes);
    }
}
