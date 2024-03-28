using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IAppsApi
    {
        Task<ResultSet<App>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default);
        IWebHooksApi WebHooks();
        IMembersApi Members();
    }
}
