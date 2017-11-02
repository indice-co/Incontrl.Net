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

        public AppsApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<App>> ListAsync(ListOptions options, CancellationToken cancellationToken) => 
            _clientBase.GetAsync<ResultSet<App>>($"api/apps", cancellationToken);
    }
}
