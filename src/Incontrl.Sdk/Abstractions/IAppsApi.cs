using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IAppsApi
    {
        Task<ResultSet<App>> ListAsync(ListOptions options, CancellationToken cancellationToken);
    }
}
