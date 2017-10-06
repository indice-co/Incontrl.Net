using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface ISubscriptionContactApi
    {
        Task<JsonResponse<Contact>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<JsonResponse<Contact>> UpdateAsync(UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken));
    }
}
