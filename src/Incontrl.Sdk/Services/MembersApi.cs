using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class MembersApi(ClientBase clientBase) : IMembersApi
    {
        public Task<ResultSet<MemberInfo>> ListAsync(MemberRequest request, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<MemberInfo>>($"api/apps/members", request, cancellationToken);
    }
}
