using System.Net.Http;
using System.Text;
using System.Text.Json;
using Indice.Serialization;

namespace Incontrl.Sdk.Http
{
    internal class JsonRequest : StringContent
    {
        private static readonly JsonSerializerOptions _serializerSettings = JsonSerializerOptionDefaults.GetDefaultSettings();

        private JsonRequest(string content) : base(content, Encoding.UTF8, "application/json") { }

        public static JsonRequest For<T>(T payload) => new JsonRequest(JsonSerializer.Serialize(payload, _serializerSettings));
    }
}
