using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using Indice.Serialization;

namespace Incontrl.Sdk.Http
{
    internal class JsonResponse : JsonResponse<string>
    {
        public JsonResponse(string raw) : base(raw) { }

        public JsonResponse(string raw, HttpStatusCode statusCode, string reason) : base(raw, statusCode, reason) { }
    }

    internal class JsonResponse<T>
    {
        private readonly string _httpErrorReason;
        private static readonly JsonSerializerOptions _serializerSettings = JsonSerializerOptionDefaults.GetDefaultSettings();

        public bool IsHttpError { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }
        public T Data { get; private set; }
        public string[] Errors { get; private set; } = Array.Empty<string>();
        public string HttpErrorReason { get; private set; }

        public JsonResponse(string raw) {
            try {
                if (string.IsNullOrWhiteSpace(raw)) {
                    Data = default;
                } else if (typeof(T).Equals(typeof(string))) {
                    Data = (T)(object)raw;
                } else {
                    Data = JsonSerializer.Deserialize<T>(raw, _serializerSettings);
                }
            } catch (JsonException exception) {
                throw new InvalidOperationException($"Invalid JSON response: {exception}");
            }
        }

        public JsonResponse(string raw, HttpStatusCode statusCode, string reason) {
            IsHttpError = true;
            HttpStatusCode = statusCode;
            HttpErrorReason = reason;
            try {
                if (string.IsNullOrWhiteSpace(raw)) {
                    return;
                }
                if (statusCode == HttpStatusCode.BadRequest) {
                    var validationProblemDetails = JsonSerializer.Deserialize<ValidationProblemDetails>(raw, _serializerSettings);
                    Errors = validationProblemDetails.ExtractErrors().ToArray();
                    if (Errors.Length == 0) {
                        Errors = new[] { raw };
                    }
                }
            } catch (JsonException exception) {
                throw new InvalidOperationException("Invalid JSON response", exception);
            }
        }
    }

    internal class ValidationProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
        public string Title { get; set; }
        public string Details { get; set; }
        public IEnumerable<string> ExtractErrors() {
            if (!string.IsNullOrWhiteSpace(Details)) {
                yield return Details;
            }
            foreach (var errorPair in Errors) {
                foreach (var item in errorPair.Value) {
                    yield return item;
                }
            }
        }
    }

    internal class ProblemDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public IDictionary<string, object> Extensions { get; set; }
    }
}
