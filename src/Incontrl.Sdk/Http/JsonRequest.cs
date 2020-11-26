using System.Globalization;
using System.Net.Http;
using System.Text;
using Incontrl.Sdk.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Incontrl.Sdk.Http
{
    internal class JsonRequest : StringContent
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings {
            Culture = CultureInfo.CurrentCulture,
            ContractResolver = new CamelCaseExceptDictionaryKeysResolver(),
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        private JsonRequest(string content) : base(content, Encoding.UTF8, "application/json") {
            _serializerSettings.Converters.Add(new StringEnumConverter {
                CamelCaseText = false
            });
        }

        public static JsonRequest For<T>(T payload) => new JsonRequest(JsonConvert.SerializeObject(payload, _serializerSettings));
    }
}
