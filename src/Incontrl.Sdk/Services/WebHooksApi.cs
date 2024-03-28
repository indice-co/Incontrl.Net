using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class WebHooksApi(ClientBase clientBase) : IWebHooksApi
    {
        public Task<ResultSet<Webhook>> ListAsync(ListOptions<WebhookFilter> options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<ResultSet<Webhook>>($"api/apps/all/webhooks", options, cancellationToken);
    }
}
