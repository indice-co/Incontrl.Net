using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Incontrl.Net.Http;

namespace Incontrl.Net.Services
{
    internal class ClientBase
    {
        protected static HttpClient _client;
        private static string AccessToken { get; set; }

        public ClientBase(string address, string clientName, string clientSecret) : this(address, clientName, clientSecret, new HttpClientHandler()) { }

        public ClientBase(string address, string clientName, string clientSecret, HttpMessageHandler innerHttpClientHandler) {
            if (address == null) {
                throw new ArgumentNullException(nameof(address));
            }

            if (innerHttpClientHandler == null) {
                throw new ArgumentNullException(nameof(innerHttpClientHandler));
            }

            _client = _client ?? Task.Run(() => CreateHttpClientAsync(address, clientName, clientSecret, innerHttpClientHandler)).Result;
        }

        public async Task<JsonResponse<TResponse>> GetAsync<TResponse>(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = $"?{string.Join("&", ObjectToDictionary(query).Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)))}";
            }

            if (!string.IsNullOrEmpty(AccessToken)) {
                _client.SetBearerToken(AccessToken);
            }

            var response = default(JsonResponse<TResponse>);
            var uri = string.Format(requestUri + queryString);
            var httpMessage = await _client.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpMessage.StatusCode == HttpStatusCode.OK || httpMessage.StatusCode == HttpStatusCode.NotModified) {
                var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                response = new JsonResponse<TResponse>(content);
            } else {
                var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response;
        }

        public async Task<JsonResponse<TResponse>> PostAsync<TRequest, TResponse>(string requestUri, TRequest model, CancellationToken cancellationToken = default(CancellationToken)) {
            var response = default(JsonResponse<TResponse>);
            var uri = string.Format(requestUri);
            var httpMessage = await _client.PostAsync(requestUri, JsonRequest.For(model), cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response;
        }

        public async Task<JsonResponse<TResponse>> PostAsync<TResponse>(string requestUri, MultipartContent multiPartContent, CancellationToken cancellationToken = default(CancellationToken)) {
            var response = default(JsonResponse<TResponse>);
            var uri = string.Format(requestUri);
            var httpMessage = await _client.PostAsync(requestUri, multiPartContent, cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response;
        }

        public async Task<JsonResponse<TResponse>> PutAsync<TRequest, TResponse>(string requestUri, TRequest model, CancellationToken cancellationToken = default(CancellationToken)) {
            var response = default(JsonResponse<TResponse>);
            var httpMessage = await _client.PutAsync(requestUri, JsonRequest.For(model), cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response;
        }

        public async Task<JsonResponse<TResponse>> DeleteAsync<TResponse>(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = $"?{string.Join("&", ObjectToDictionary(query).Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)))}";
            }

            var response = default(JsonResponse<TResponse>);
            var httpMessage = await _client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response;
        }

        #region Private Methods
        private async static Task<HttpClient> CreateHttpClientAsync(string address, string clientName, string clientSecret, HttpMessageHandler innerHttpClientHandler) {
            var client = new HttpClient(innerHttpClientHandler) {
                BaseAddress = new Uri(address)
            };

            var discoveryResponse = await DiscoveryClient.GetAsync(IdentityServerConstants.Authority);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, clientName, clientSecret);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(Api.ResourceName);

            if (tokenResponse.IsError) {
                // We need to handle this properly.
                return null;
            }

            client.SetBearerToken(tokenResponse.AccessToken);
            return client;
        }

        private static Dictionary<string, string> ObjectToDictionary(object values) {
            if (values == null) {
                return null;
            }

            if (values is Dictionary<string, string> dictionary) {
                return dictionary;
            }

            dictionary = new Dictionary<string, string>();

            foreach (var property in values.GetType().GetRuntimeProperties()) {
                var value = property.GetValue(values);

                if (value != null) {
                    var textValue = value.ToString();

                    if (!string.IsNullOrEmpty(textValue)) {
                        dictionary.Add(property.Name, textValue);
                    }
                }
            }

            return dictionary;
        }

        private static void HandleHttpError<TResponse>(JsonResponse<TResponse> httpResponse) { }
        #endregion
    }
}
