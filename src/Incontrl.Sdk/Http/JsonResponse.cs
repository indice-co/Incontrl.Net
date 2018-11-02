using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        private JObject _errors;

        // Class properties.
        public bool IsHttpError { get; private set; }
        public HttpStatusCode HttpErrorStatusCode { get; private set; }
        public T Data { get; private set; }

        public JsonResponse(string raw) {
            try {
                if (null == raw) {
                    Data = default(T);
                } else if (typeof(T).Equals(typeof(string))) {
                    Data = (T)(object)raw;
                } else {
                    var settings = new JsonSerializerSettings();
                    Data = JsonConvert.DeserializeObject<T>(raw, settings);
                }
            } catch (Exception exception) {
                throw new InvalidOperationException($"Invalid JSON response: {exception}");
            }
        }

        public JsonResponse(string raw, HttpStatusCode statusCode, string reason) {
            IsHttpError = true;
            HttpErrorStatusCode = statusCode;
            _httpErrorReason = reason;

            try {
                _errors = new JObject { };

                if (!string.IsNullOrEmpty(raw) && raw.StartsWith("{")) {
                    _errors = JObject.Parse(raw);
                } else if (!string.IsNullOrEmpty(raw) && raw.StartsWith("<")) {
                    // Errors are html so do nothing.
                } else if (!string.IsNullOrEmpty(raw)) {
                    _errors = JObject.Parse($@"{{""message"": """"}}");
                    _errors["message"] = raw;
                }
            } catch (Exception exception) {
                throw new InvalidOperationException("Invalid JSON response", exception);
            }
        }

        public string[] Errors {
            get {
                var errors = new List<string>();

                if (IsHttpError && _errors.Count > 0) {
                    if (_errors["ModelState"] != null) {
                        foreach (var item in _errors["ModelState"].Values()) {
                            foreach (var msg in item.Values<string>()) {
                                errors.Add(msg);
                            }
                        }

                        return errors.ToArray();
                    }

                    if (_errors["Message"] != null) {
                        return new[] { _errors["Message"].ToString() };
                    }

                    foreach (var item in _errors.Values()) {
                        if (!item.HasValues) {
                            errors.Add(item.Value<string>());
                            continue;
                        }

                        foreach (var msg in item.Values<string>()) {
                            errors.Add(msg);
                        }
                    }

                    return errors.ToArray();

                }

                return new[] { _httpErrorReason };
            }
        }

        public string HttpErrorReason => Errors.Aggregate(new StringBuilder(), (stringBuilder, message) => stringBuilder.AppendLine($"• {message}"), stringBuilder => stringBuilder.ToString());
    }
}
