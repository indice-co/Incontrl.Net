using System;
using System.IO;
using System.Net.Http;
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

        public Task<Link> LogoUploadAsync(Stream fileContent, string fileName, CancellationToken cancellationToken = default) {
            return clientBase.PostFileAsync<Link>(HttpMethod.Put, $"subscriptions/{SubscriptionId}/company/logo", fileContent, fileName, formData: null, cancellationToken);
        }
        public Task<Link> LogoSetUriAsync(Uri absoluteUri, CancellationToken cancellationToken = default) {
            var form = new System.Collections.Specialized.NameValueCollection {
                { "imageUrl", absoluteUri.ToString() }
            };
            return clientBase.PostFileAsync<Link>(HttpMethod.Put, $"subscriptions/{SubscriptionId}/company/logo", fileContent:null, fileName: null, formData: form, cancellationToken);
        }

    }
}
