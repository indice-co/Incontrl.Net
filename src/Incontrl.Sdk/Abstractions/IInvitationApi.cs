using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Abstractions
{
    public interface IInvitationApi
    {
        string SubscriptionId { get; set; }
        string InvitationId { get; set; }

        Task<InvitationResult> SendAsync(string email, CancellationToken cancellationToken = default);
        Task AcceptAsync(string memberId, CancellationToken cancellationToken = default);
    }
}
