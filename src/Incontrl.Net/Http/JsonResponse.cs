using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Incontrl.Net.Http
{
    public class JsonResponse<T>
    {
        // Private variables.
        private readonly T _data;
        private bool _isHttpError;
        private HttpStatusCode _httpErrorstatusCode;
        private string _httpErrorReason;
        private JObject _errors;

        // Class properties.
        public bool IsHttpError => _isHttpError;
        public HttpStatusCode HttpErrorStatusCode => _httpErrorstatusCode;
        public T Data => _data;

        public JsonResponse(string raw) {
            try {
                if (null == raw) {
                    _data = default(T);
                } else if (typeof(T).Equals(typeof(string))) {
                    _data = (T)(object)raw;
                } else {
                    var settings = new JsonSerializerSettings();
                    _data = JsonConvert.DeserializeObject<T>(raw, settings);
                }
            } catch (Exception exception) {
                throw new InvalidOperationException($"Invalid JSON response: {exception}");
            }
        }

        public JsonResponse(string raw, HttpStatusCode statusCode, string reason) {
            _isHttpError = true;
            _httpErrorstatusCode = statusCode;
            _httpErrorReason = reason;

            try {
                _errors = new JObject() { };

                if (!string.IsNullOrEmpty(raw) && raw.StartsWith("{")) {
                    _errors = JObject.Parse(raw);
                } else if (!string.IsNullOrEmpty(raw) && raw.StartsWith("<")) {
                    // Errors are HTML so do nothing.
                } else if (!string.IsNullOrEmpty(raw)) {
                    _errors = JObject.Parse($@"{{""mesage"": ""{raw}""}}");
                }
            } catch (Exception exception) {
                throw new InvalidOperationException($"Invalid JSON response: {exception}");
            }
        }

        public string HttpErrorReason {
            get {
                if (IsHttpError && _errors.Count > 0) {
                    if (_errors["ModelState"] != null) {
                        foreach (var item in _errors["ModelState"].Values()) {
                            foreach (var msg in item.Values<string>()) {
                                new StringBuilder().AppendLine($"• {msg}");
                            }
                        }

                        return new StringBuilder().ToString();
                    }

                    if (_errors["Message"] != null) {
                        return _errors["Message"].ToString();
                    }

                    foreach (var item in _errors.Values()) {
                        foreach (var msg in item.Values<string>()) {
                            new StringBuilder().AppendLine($"• {msg}");
                        }
                    }

                    return new StringBuilder().ToString();

                }

                return _httpErrorReason;
            }
        }
    }
}