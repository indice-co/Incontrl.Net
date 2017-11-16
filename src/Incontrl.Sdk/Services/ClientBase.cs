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
        protected static HttpClient Client;
        private readonly string _appId;
        private readonly string _apiKey;
        private readonly HttpMessageHandler _innerHttpClientHandler;

        public ClientBase(string appId, string apiKey) : this(appId, apiKey, new HttpClientHandler()) { }

        public ClientBase(string appId, string apiKey, HttpMessageHandler innerHttpClientHandler) {
            if (string.IsNullOrWhiteSpace(appId)) {
                throw new ArgumentNullException(nameof(appId), "Please specify an application id.");
            }

            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new ArgumentNullException(nameof(apiKey), "Please specify and API key.");
            }

            _appId = appId;
            _apiKey = apiKey;
            _innerHttpClientHandler = innerHttpClientHandler ?? throw new ArgumentNullException(nameof(innerHttpClientHandler));
            Client = Client ?? new HttpClient(innerHttpClientHandler);
#if DEBUG
            AuthorityAddress = new Uri("http://localhost:20200");
            ApiAddress = new Uri("http://localhost:20202");
#elif RELEASE
            AuthorityAddress = new Uri("https://incontrl.io");
            ApiAddress = new Uri("https://api.incontrl.io");
#endif
        }

        public Uri AuthorityAddress { get; set; }
        public Uri ApiAddress { get; set; }

        public async Task RequestResourceOwnerPasswordAsync(string userName, string password, ScopeFlags scopes) {
            var discoveryResponse = await DiscoveryClient.GetAsync(AuthorityAddress.AbsoluteUri);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(userName, password, scopes.ToScopesText());

            if (tokenResponse.IsError) {
                HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }

            Client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task RequestClientCredentialsAsync(ScopeFlags scopes) {
            var discoveryResponse = await DiscoveryClient.GetAsync(AuthorityAddress.AbsoluteUri);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync(scopes.ToScopesText());

            if (tokenResponse.IsError) {
                HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }

            Client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task RequestRefreshTokenAsync(string refreshToken, ScopeFlags scopes) {
            var discoveryResponse = await DiscoveryClient.GetAsync(AuthorityAddress.AbsoluteUri);
            var tokenClient = new TokenClient(discoveryResponse.TokenEndpoint, _appId, _apiKey);
            var tokenResponse = await tokenClient.RequestRefreshTokenAsync(refreshToken, scopes.ToScopesText());

            if (tokenResponse.IsError) {
                HandleHttpError(new JsonResponse(tokenResponse.Raw, tokenResponse.HttpStatusCode, tokenResponse.HttpErrorReason));
            }

            Client.SetBearerToken(tokenResponse.AccessToken);
        }

        public async Task<TResponse> GetAsync<TResponse>(string requestUri, object query = null, CancellationToken cancellationToken = default(CancellationToken)) {
            var queryString = string.Empty;

            if (query != null) {
                queryString = "?" + new QueryStringParams(query).ToString();
            }

            var response = default(JsonResponse<TResponse>);
            var uri = string.Format(requestUri + queryString);
            var httpMessage = await Client.GetAsync(uri, cancellationToken).ConfigureAwait(false);
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
                queryString = "?" + new QueryStringParams(query).ToString();
            }

            FileResult response = null;
            var uri = string.Format(requestUri + queryString);
            var httpMessage = await Client.GetAsync(uri, cancellationToken).ConfigureAwait(false);

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
            var httpMessage = await Client.PostAsync(requestUri, JsonRequest.For(model), cancellationToken).ConfigureAwait(false);
            var content = await httpMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                HandleHttpError(response);
            }

            return response.Data;
        }

        public async Task PostFileAsync(string requestUri, Stream fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken)) {
            using (var formDataContent = new MultipartFormDataContent("upload-" + Guid.NewGuid().ToString().ToLower())) {
                var streamContent = new StreamContent(fileContent);
                var fileExtension = Path.GetExtension(fileName);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeTypeFromExtension(fileExtension));
                formDataContent.Add(streamContent, "file", fileName);
                await Client.PostAsync(requestUri, formDataContent, cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<TResponse> PostAsync<TResponse>(string requestUri, MultipartContent multiPartContent, CancellationToken cancellationToken = default(CancellationToken)) {
            var response = default(JsonResponse<TResponse>);
            var uri = string.Format(requestUri);
            var httpMessage = await Client.PostAsync(requestUri, multiPartContent, cancellationToken).ConfigureAwait(false);
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
            var httpMessage = await Client.PutAsync(requestUri, JsonRequest.For(model), cancellationToken).ConfigureAwait(false);
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
                queryString = "?" + new QueryStringParams(query).ToString();
            }

            await Client.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
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
