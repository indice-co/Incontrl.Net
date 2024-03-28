using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class SubscriptionCompanyApi(ClientBase clientBase) : ISubscriptionCompanyApi
    {
        public string SubscriptionId { get; set; }

        public Task<Organisation> GetAsync(CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<Organisation>($"subscriptions/{SubscriptionId}/company", cancellationToken);

        public Task<Organisation> UpdateAsync(UpdateCompanyRequest request, CancellationToken cancellationToken = default) => 
            clientBase.PutAsync<UpdateCompanyRequest, Organisation>($"subscriptions/{SubscriptionId}/company", request, cancellationToken);

        public Task LogoUploadAsync(Stream fileContent, string fileName, CancellationToken cancellationToken = default) =>
            clientBase.PostFileAsync($"subscriptions/{SubscriptionId}/company/logo", fileContent, fileName, cancellationToken);
    }
}
