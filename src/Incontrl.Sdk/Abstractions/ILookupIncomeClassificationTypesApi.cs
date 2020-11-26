using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface ILookupIncomeClassificationTypesApi
    {
        Task<ResultSet<Classification>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
