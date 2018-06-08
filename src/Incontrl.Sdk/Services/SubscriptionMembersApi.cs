using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionMembersApi : ISubscriptionMembersApi
    {
        private readonly ClientBase _clientBase;

        public SubscriptionMembersApi(ClientBase clientBase) => _clientBase = clientBase;

        public string SubscriptionId { get; set; }

        public Task<ResultSet<MemberInfo>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<ResultSet<MemberInfo>>($"subscriptions/{SubscriptionId}/members", cancellationToken);
    }
}
