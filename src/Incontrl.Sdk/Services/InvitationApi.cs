using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class InvitationApi(ClientBase clientBase) : IInvitationApi
    {
        public string SubscriptionId { get; set; }
        public string InvitationId { get; set; }

        public Task<InvitationResult> SendAsync(string email, CancellationToken cancellationToken = default) =>
            clientBase.PostAsync<InvitationRequest, InvitationResult>($"subscriptions/{SubscriptionId}/invite", new InvitationRequest { RecipientEmail = email }, cancellationToken);

        public Task AcceptAsync(string memberId, CancellationToken cancellationToken = default) =>
            clientBase.PostAsync<AcceptInvitationRequest, object>($"subscriptions/accept-invitation", new AcceptInvitationRequest { InvitationId = InvitationId, MemberId = memberId }, cancellationToken);
    }
}
