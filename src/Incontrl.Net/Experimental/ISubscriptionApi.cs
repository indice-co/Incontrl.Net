using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Experimental
{
    public interface ISubscriptionApi
    {

        Task<JsonResponse<Subscription>> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
        
        IOrganisationsApi Organisations();
        IOrganisationApi Organisations(Guid organisationId);
    }
}