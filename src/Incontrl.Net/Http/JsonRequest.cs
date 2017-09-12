using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Incontrl.Net.Http
{
    public class JsonRequest : StringContent
    {
        private JsonRequest(string content) : base(content, Encoding.UTF8, "application/json") { }

        public static JsonRequest For<T>(T payload) => new JsonRequest(JsonConvert.SerializeObject(payload));
    }
}