using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IWebHooksApi
    {
        Task<ResultSet<Webhook>> ListAsync(ListOptions<WebhookFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
