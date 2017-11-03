using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IAppApi
    {
        string AppId { get; set; }
        Task<App> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
