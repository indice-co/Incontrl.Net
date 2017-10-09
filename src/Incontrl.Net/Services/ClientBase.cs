using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Services
{
    internal class ClientBase
    {
        protected static HttpClient _client;
        private string _address;
        private string _appId;
        private string _apiKey;
        private HttpMessageHandler _innerHttpClientHandler;

        public ClientBase(string address, string appId, string apiKey) : this(address, appId, apiKey, new HttpClientHandler()) { }

        public ClientBase(string address, string appId, string apiKey, HttpMessageHandler innerHttpClientHandler) {
            if (string.IsNullOrWhiteSpace(appId)) {
                throw new ArgumentNullException(nameof(appId), "Please specify an application id.");
            }

            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new ArgumentNullException(nameof(apiKey), "Please specify and API key.");
            }

            _appId = appId;
            _apiKey = apiKey;
            _address = address ?? throw new ArgumentNullException(nameof(address));
            _innerHttpClientHandler = innerHttpClientHandler ?? throw new ArgumentNullException(nameof(innerHttpClientHandler));

            _client = _client ?? new HttpClient(innerHttpClientHandler) {
                BaseAddress = new Uri(address)
            };
        }

        public async Task RequestResourceOwnerPasswordAsync(string userName, string password) {
            var discoveryResponse = await DiscoveryClient.GetAsync(IdentityServerConstants.AUTHORITY);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(userName, password, Api.RESOURCE_NAME);

            if (tokenResponse.IsError) {
                HandleHttpError(tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason);
            }

            _client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task RequestClientCredentialsAsync() {
            var discoveryResponse = await DiscoveryClient.GetAsync(IdentityServerConstants.AUTHORITY);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(Api.RESOURCE_NAME);

            if (tokenResponse.IsError) {
                HandleHttpError(tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason);
            }

            _client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task RequestRefreshTokenAsync(string refreshToken) {
            var discoveryResponse = await DiscoveryClient.GetAsync(IdentityServerConstants.AUTHORITY);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestRefreshTokenAsync(refreshToken);

            if (tokenResponse.IsError) {
                HandleHttpError(tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason);
            }

            _client.SetBearerToken(tokenResponse.AccessToken);
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
                HandleHttpError(httpMessage.StatusCode, httpMessage.ReasonPhrase);
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
                HandleHttpError(httpMessage.StatusCode, httpMessage.ReasonPhrase);
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
                HandleHttpError(httpMessage.StatusCode, httpMessage.ReasonPhrase);
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
                HandleHttpError(httpMessage.StatusCode, httpMessage.ReasonPhrase);
            }

            return response;
        }

        public async Task DeleteAsync(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = $"?{string.Join("&", ObjectToDictionary(query).Select(kv => string.Format("{0}={1}", kv.Key, kv.Value)))}";
            }

            await _client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
        }

        #region Private Methods
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

        private static void HandleHttpError(HttpStatusCode httpStatusCode, string reasonPhrase) {
            switch (httpStatusCode) {
                case HttpStatusCode.Forbidden:
                    throw new IncontrlException($"It seems that you have no right to access this resource. Reason Phrase: {reasonPhrase}");
                case HttpStatusCode.Unauthorized:
                    throw new IncontrlException($"It seems that your credentials are not correct. Reason Phrase: {reasonPhrase}");
                case HttpStatusCode.BadRequest:
                    throw new IncontrlException($"The request you performed is not valid. Reason Phrase: {reasonPhrase}");
            }
        }

        private static string GetMimeTypeFromExtension(string extension) {
            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
                {".htm", "text/html"},
                {".html", "text/html"}
            };

            return mappings.ContainsKey(extension) ? mappings[extension] : string.Empty;
        }
        #endregion
    }
}
