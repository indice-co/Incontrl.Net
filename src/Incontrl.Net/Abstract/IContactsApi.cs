using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstract
{
    public interface IContactsApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<ResultSet<Contact>>> ListAsync(ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Contact>> CreateAsync(CreateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken));
    }
}
