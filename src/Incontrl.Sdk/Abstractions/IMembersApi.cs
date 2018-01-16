using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Abstractions
{
    public interface IMembersApi
    {
        Task<ResultSet<MemberInfo>> ListAsync(List<string> ids, CancellationToken cancellationToken = default(CancellationToken));
    }
}
