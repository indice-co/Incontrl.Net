using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstract
{
    public interface ISubscriptionContactApi
    {
        string SubscriptionId { get; set; }
        Task<JsonResponse<Contact>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Contact>> UpdateAsync(UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken));
    }
}
