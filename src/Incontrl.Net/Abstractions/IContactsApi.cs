using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IContactsApi
    {
        string SubscriptionId { get; set; }
        Task<ResultSet<Contact>> ListAsync(ListOptions<ContactFilter> options = null, CancellationToken cancellationToken = default(CancellationToken));
        Task<Contact> CreateAsync(CreateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken));
    }
}
