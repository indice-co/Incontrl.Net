using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class AppApi(Func<ClientBase> clientBaseFactory) : IAppApi
    {
        private readonly ClientBase _clientBase = clientBaseFactory();

        public string AppId { get; set; }

        public Task<App> GetAsync(CancellationToken cancellationToken = default) =>
            _clientBase.GetAsync<App>($"api/apps/{AppId}", cancellationToken);
    }
}
