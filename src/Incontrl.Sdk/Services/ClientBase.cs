using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Http;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal sealed class ClientBase
    {
        private static HttpClient _httpClient;

        public ClientBase(HttpClient httpClient) => _httpClient = httpClient ?? new HttpClient();

        public async Task<TResponse> GetAsync<TResponse>(string requestUri, object query = null, CancellationToken cancellationToken = default) {
            var queryString = string.Empty;
            if (query != null) {
                queryString = "?" + new QueryStringParams(query).ToString();
            }
            var uri = string.Format($"{requestUri}{queryString}");
            var httpMessage = await _httpClient.GetAsync(uri, cancellationToken);
            var content = await httpMessage.Content.ReadAsStringAsync();
            JsonResponse<TResponse> response;
            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                httpMessage.HandleHttpError(response);
            }
            return response.Data;
        }

        public async Task<FileResult> GetStreamAsync(string requestUri, object query = null, CancellationToken cancellationToken = default) {
            var queryString = string.Empty;
            if (query != null) {
                queryString = "?" + new QueryStringParams(query).ToString();
            }
            FileResult response = null;
            var uri = string.Format($"{requestUri}{queryString}");
            var httpMessage = await _httpClient.GetAsync(uri, cancellationToken);
            if (httpMessage.IsSuccessStatusCode && httpMessage.Content.Headers.ContentDisposition != null) {
                response = new FileResult {
                    FileName = httpMessage.Content.Headers.ContentDisposition.FileName,
                    Stream = await httpMessage.Content.ReadAsStreamAsync()
                };
            }
            return response;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest model, CancellationToken cancellationToken = default) {
            var uri = string.Format(requestUri);
            var httpMessage = await _httpClient.PostAsync(uri, JsonRequest.For(model), cancellationToken);
            var content = await httpMessage.Content.ReadAsStringAsync();
            JsonResponse<TResponse> response;
            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                httpMessage.HandleHttpError(response);
            }
            return response.Data;
        }

        public async Task<TResponse> PostAsync<TResponse>(string requestUri, MultipartContent multiPartContent, CancellationToken cancellationToken = default) {
            var httpMessage = await _httpClient.PostAsync(requestUri, multiPartContent, cancellationToken);
            var content = await httpMessage.Content.ReadAsStringAsync();
            JsonResponse<TResponse> response;
            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                httpMessage.HandleHttpError(response);
            }
            return response.Data;
        }

        public async Task PostFileAsync(string requestUri, Stream fileContent, string fileName, CancellationToken cancellationToken = default) {
            using (var formDataContent = new MultipartFormDataContent("upload-" + Guid.NewGuid().ToString().ToLower())) {
                var streamContent = new StreamContent(fileContent);
                var fileExtension = Path.GetExtension(fileName);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(GetMimeTypeFromExtension(fileExtension));
                formDataContent.Add(streamContent, "file", fileName);
                await _httpClient.PostAsync(requestUri, formDataContent, cancellationToken);
            }
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest model, CancellationToken cancellationToken = default) {
            var httpMessage = await _httpClient.PutAsync(requestUri, JsonRequest.For(model), cancellationToken);
            var content = await httpMessage.Content.ReadAsStringAsync();
            JsonResponse<TResponse> response;
            if (httpMessage.IsSuccessStatusCode) {
                response = new JsonResponse<TResponse>(content);
            } else {
                response = new JsonResponse<TResponse>(content, httpMessage.StatusCode, httpMessage.ReasonPhrase);
                httpMessage.HandleHttpError(response);
            }
            return response.Data;
        }

        public async Task DeleteAsync(string requestUri, object query = null, CancellationToken cancellationToken = default) {
            var queryString = string.Empty;
            if (query != null) {
                queryString = "?" + new QueryStringParams(query).ToString();
            }
            var httpMessage = await _httpClient.DeleteAsync($"{requestUri}{queryString}", cancellationToken);
            if (!httpMessage.IsSuccessStatusCode) {
                httpMessage.HandleHttpError(new JsonResponse(string.Empty, httpMessage.StatusCode, string.Empty));
            }
        }

        #region Private Methods
        private static string GetMimeTypeFromExtension(string extension) {
            var mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
                [".docx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                [".htm"] = "text/html",
                [".html"] = "text/html",
                [".jpg"] = "image/jpeg",
                [".png"] = "image/png",
                [".gif"] = "image/gif",
                [".svg"] = "image/svg+xml",
            };
            return mappings.ContainsKey(extension) ? mappings[extension] : string.Empty;
        }
        #endregion
    }
}
