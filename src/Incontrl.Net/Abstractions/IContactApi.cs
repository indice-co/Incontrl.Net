using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IContactApi
    {
        string SubscriptionId { get; set; }
        string ContactId { get; set; }
        Task<Contact> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<Contact> UpdateAsync(UpdateContactRequest contact, CancellationToken cancellationToken = default(CancellationToken));
        IContactCompaniesApi Companies();
    }
}
