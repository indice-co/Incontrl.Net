using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionMembersApi(ClientBase clientBase) : ISubscriptionMembersApi
    {
        public string SubscriptionId { get; set; }

        public Task<ResultSet<MemberInfo>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) =>
            clientBase.GetAsync<ResultSet<MemberInfo>>($"subscriptions/{SubscriptionId}/members", cancellationToken);
    }
}
