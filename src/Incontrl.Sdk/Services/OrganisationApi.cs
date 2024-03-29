using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class OrganisationApi(ClientBase clientBase) : IOrganisationApi
    {
        public string SubscriptionId { get; set; }
        public string OrganisationId { get; set; }

        public Task<Organisation> GetAsync(CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<Organisation>($"subscriptions/{SubscriptionId}/organisations/{OrganisationId}", cancellationToken);

        public Task<Organisation> UpdateAsync(UpdateOrganisationRequest request, CancellationToken cancellationToken = default) => 
            clientBase.PutAsync<UpdateOrganisationRequest, Organisation>($"subscriptions/{SubscriptionId}/organisations/{OrganisationId}", request, cancellationToken);

        public Task<Link> LogoUploadAsync(Stream fileContent, string fileName, CancellationToken cancellationToken = default) =>
            clientBase.PostFileAsync<Link>(HttpMethod.Put, $"subscriptions/{SubscriptionId}/organisations/{OrganisationId}/logo", fileContent, fileName, formData:null, cancellationToken);

        public Task<Link> LogoSetUriAsync(Uri absoluteUri, CancellationToken cancellationToken = default) {
            var form = new System.Collections.Specialized.NameValueCollection {
                { "imageUrl", absoluteUri.ToString() }
            };
            return clientBase.PostFileAsync<Link>(HttpMethod.Put, $"subscriptions/{SubscriptionId}/company/logo", fileContent: null, fileName: null, formData: form, cancellationToken);
        }
        public Task DeleteAsync(CancellationToken cancellationToken = default) =>
            clientBase.DeleteAsync($"subscriptions/{SubscriptionId}/organisations/{OrganisationId}", cancellationToken);
    }
}
