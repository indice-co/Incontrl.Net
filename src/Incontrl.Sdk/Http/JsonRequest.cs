using System.Globalization;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Incontrl.Sdk.Http
{
    internal class JsonRequest : StringContent
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings {
            Culture = CultureInfo.CurrentCulture,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            ContractResolver = new DefaultContractResolver {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        static JsonRequest() {
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        private JsonRequest(string content) : base(content, Encoding.UTF8, "application/json") { }

        public static JsonRequest For<T>(T payload) => new JsonRequest(JsonConvert.SerializeObject(payload, _serializerSettings));
    }
}
