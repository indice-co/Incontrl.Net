using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Incontrl.Net.Http;
using Incontrl.Net.Models;

namespace Incontrl.Net.Services
{
    internal class ClientBase
    {
        protected static HttpClient _client;
        private static string AccessToken { get; set; }

        public ClientBase(string address, string appId, string apiKey) : this(address, appId, apiKey, new HttpClientHandler()) { }

        public ClientBase(string address, string appId, string apiKey, HttpMessageHandler innerHttpClientHandler) {
            if (address == null) {
                throw new ArgumentNullException(nameof(address));
            }

            if (innerHttpClientHandler == null) {
                throw new ArgumentNullException(nameof(innerHttpClientHandler));
            }

            _client = _client ?? Task.Run(() => CreateHttpClientAsync(address, appId, apiKey, innerHttpClientHandler)).Result;
        }

        public async Task<JsonResponse<TResponse>> GetAsync<TResponse>(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = $"?{string.Join("&", ObjectToDictionary(query).Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)))}";
            }

            var response = default(JsonResponse<TResponse>);
            var uri = string.Format(requestUri + queryString);
            var httpMessage = await _client.GetAsync(uri, cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response;
        }

        public async Task<FileResult> GetStreamAsync(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = $"?{string.Join("&", ObjectToDictionary(query).Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)))}";
            }

            FileResult response = null;
            var uri = string.Format(requestUri + queryString);
            var httpMessage = await _client.GetAsync(uri, cancellationToken).ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode && httpMessage.Content.Headers.ContentDisposition != null) {
                response = new FileResult {
                    FileName = httpMessage.Content.Headers.ContentDisposition.FileName,
                    Stream = await httpMessage.Content.ReadAsStreamAsync()
                };
            }

            return response;
        }

        public async Task<JsonResponse<TResponse>> PostAsync<TRequest, TResponse>(string requestUri, TRequest model, CancellationToken cancellationToken = default(CancellationToken)) {
            var response = default(JsonResponse<TResponse>);
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

        public async Task PostFileAsync(string requestUri, byte[] fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken)) {
            using (var formDataContent = new MultipartFormDataContent("upload-" + Guid.NewGuid().ToString().ToLower())) {
                var streamContent = new StreamContent(new MemoryStream(fileContent));
                var fileExtension = Path.GetExtension(fileName);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeTypeFromExtension(fileExtension));
                formDataContent.Add(streamContent, "file", fileName);
                await _client.PostAsync(requestUri, formDataContent, cancellationToken).ConfigureAwait(false);
            }
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

        public async Task DeleteAsync(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = $"?{string.Join("&", ObjectToDictionary(query).Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)))}";
            }

            var httpMessage = await _client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);

            if (!httpMessage.IsSuccessStatusCode) {
                //HandleHttpError(response);
            }
        }

        #region Private Methods
        private async static Task<HttpClient> CreateHttpClientAsync(string address, string appId, string apiKey, HttpMessageHandler innerHttpClientHandler) {
            var client = new HttpClient(innerHttpClientHandler) {
                BaseAddress = new Uri(address)
            };

            var discoveryResponse = await DiscoveryClient.GetAsync(IdentityServerConstants.AUTHORITY);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, appId, apiKey);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(Api.RESOURCE_NAME);

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

        private static string GetMimeTypeFromExtension(string extension) {
            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".htm", "text/html"},
                {".html", "text/html"}
            };

            return mappings.ContainsKey(extension) ? mappings[extension] : string.Empty;
        }
        #endregion

        ~ClientBase() => _client?.Dispose();
    }
}
