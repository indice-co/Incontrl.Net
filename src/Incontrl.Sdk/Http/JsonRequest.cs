using System.Globalization;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Incontrl.Sdk.Http
{
    internal class JsonRequest : StringContent
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings {
            Culture = CultureInfo.CurrentCulture,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        private JsonRequest(string content) : base(content, Encoding.UTF8, "application/json") {
            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public static JsonRequest For<T>(T payload) => new JsonRequest(JsonConvert.SerializeObject(payload, _serializerSettings));
    }
}
