using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class AppsApi : IAppsApi
    {
        private readonly ClientBase _clientBase;
        private readonly Lazy<IWebHooksApi> _webHooksApi;

        public AppsApi(ClientBase clientBase) {
            _clientBase = clientBase;
            _webHooksApi = new Lazy<IWebHooksApi>(() => new WebHooksApi(_clientBase));
        }

        public Task<ResultSet<App>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<App>>($"{_clientBase.AuthorityAddress}api/apps", cancellationToken);

        public IWebHooksApi WebHooks() => _webHooksApi.Value;
    }
}
