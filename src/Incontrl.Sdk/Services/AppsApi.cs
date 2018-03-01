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
        private readonly Lazy<IMembersApi> _membersApi;

        public AppsApi(Func<ClientBase> clientBaseFactory) {
            _clientBase = clientBaseFactory();
            _webHooksApi = new Lazy<IWebHooksApi>(() => new WebHooksApi(_clientBase));
            _membersApi = new Lazy<IMembersApi>(() => new MembersApi(_clientBase));
        }

        public Task<ResultSet<App>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<App>>($"api/apps", cancellationToken);

        public IMembersApi Members() => _membersApi.Value;

        public IWebHooksApi WebHooks() => _webHooksApi.Value;
    }
}
