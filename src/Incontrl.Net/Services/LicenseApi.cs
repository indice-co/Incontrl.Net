using System.Threading.Tasks;
using Incontrl.Net.Abstract;
using Incontrl.Net.Http;

namespace Incontrl.Net.Services
{
    internal class LicenseApi : ILicenseApi
    {
        private ClientBase _clientBase;

        public LicenseApi(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<JsonResponse<string>> GetAsync() => await _clientBase.GetAsync<string>("license");
    }
}
