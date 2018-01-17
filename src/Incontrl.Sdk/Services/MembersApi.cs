using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class MembersApi : IMembersApi
    {
        private readonly ClientBase _clientBase;

        public MembersApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<MemberInfo>> ListAsync(MemberRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<MemberInfo>>($"{_clientBase.AuthorityAddress}api/apps/members", request, cancellationToken);
    }
}
