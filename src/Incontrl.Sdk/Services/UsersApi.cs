using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class UsersApi(Func<ClientBase> clientBase) : IMembersApi
    {
        private readonly ClientBase _clientBase = clientBase();

        public Task<ResultSet<MemberInfo>> ListAsync(MemberRequest request, CancellationToken cancellationToken = default) =>
            _clientBase.GetAsync<ResultSet<MemberInfo>>($"api/users/members", request, cancellationToken);
    }
}
