using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.Client;
using Incontrl.Sdk.Http;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class ClientBase
    {
        protected static HttpClient _client;
        private string _appId;
        private string _apiKey;
        private HttpMessageHandler _innerHttpClientHandler;

        public ClientBase(string address, string authority, string appId, string apiKey) : this(address, authority, appId, apiKey, new HttpClientHandler()) { }

        public ClientBase(string address, string authority, string appId, string apiKey, HttpMessageHandler innerHttpClientHandler) {
            if (string.IsNullOrWhiteSpace(appId)) {
                throw new ArgumentNullException(nameof(appId), "Please specify an application id.");
            }

            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new ArgumentNullException(nameof(apiKey), "Please specify and API key.");
            }

            _appId = appId;
            _apiKey = apiKey;
            _innerHttpClientHandler = innerHttpClientHandler ?? throw new ArgumentNullException(nameof(innerHttpClientHandler));

            _client = _client ?? new HttpClient(innerHttpClientHandler) {
                BaseAddress = new Uri(address)
            };

            AuthorityAddress = new Uri(authority);
        }

        public Uri AuthorityAddress { get; }
        public Uri ApiAddress => _client.BaseAddress;

        public async Task RequestResourceOwnerPasswordAsync(string userName, string password, ScopeFlags scopes) {
            var discoveryResponse = await DiscoveryClient.GetAsync(AuthorityAddress.AbsoluteUri);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(userName, password, scopes.ToScopesText());

            if (tokenResponse.IsError) {
                HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }

            _client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task RequestClientCredentialsAsync(ScopeFlags scopes) {
            var discoveryResponse = await DiscoveryClient.GetAsync(AuthorityAddress.AbsoluteUri);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(scopes.ToScopesText());

            if (tokenResponse.IsError) {
                HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }

            _client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task RequestRefreshTokenAsync(string refreshToken, ScopeFlags scopes) {
            var discoveryResponse = await DiscoveryClient.GetAsync(AuthorityAddress.AbsoluteUri);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestRefreshTokenAsync(refreshToken, scopes.ToScopesText());

            if (tokenResponse.IsError) {
                HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }

            _client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task<TResponse> GetAsync<TResponse>(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = "?" + new Dictionary<string, object>().Merge(query).ToFormUrlEncodedString();
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

            return response.Data;
        }

        public async Task<FileResult> GetStreamAsync(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = "?" + new Dictionary<string, object>().Merge(query).ToFormUrlEncodedString();
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

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest model, CancellationToken cancellationToken = default(CancellationToken)) {
            var response = default(JsonResponse<TResponse>);
            var httpMessage = await _client.PostAsync(requestUri, JsonRequest.For(model), cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response.Data;
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

        public async Task<TResponse> PostAsync<TResponse>(string requestUri, MultipartContent multiPartContent, CancellationToken cancellationToken = default(CancellationToken)) {
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

            return response.Data;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest model, CancellationToken cancellationToken = default(CancellationToken)) {
            var response = default(JsonResponse<TResponse>);
            var httpMessage = await _client.PutAsync(requestUri, JsonRequest.For(model), cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response.Data;
        }

        public async Task DeleteAsync(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = "?" + new Dictionary<string, object>().Merge(query).ToFormUrlEncodedString();
            }

            await _client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
        }

        #region Private Methods
        private static void HandleHttpError<TResponse>(JsonResponse<TResponse> httpResponse) {
            switch (httpResponse.HttpErrorStatusCode) {
                case HttpStatusCode.InternalServerError:
                    throw new IncontrlHttpInternalServerErrorException($"There was an error on our server. It's recorded and it will be fixed. Reason Phrase: {httpResponse.HttpErrorReason}");
                case HttpStatusCode.Forbidden:
                    throw new IncontrlHttpForbiddenException($"It seems that you have no right to access this resource. Reason Phrase: {httpResponse.HttpErrorReason}");
                case HttpStatusCode.Unauthorized:
                    throw new IncontrlHttpUnauthorizedException($"It seems that your credentials are not correct. Reason Phrase: {httpResponse.HttpErrorReason}");
                case HttpStatusCode.BadRequest:
                    throw new IncontrlHttpBadRequestException(httpResponse.HttpErrorReason, httpResponse.Errors);
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
