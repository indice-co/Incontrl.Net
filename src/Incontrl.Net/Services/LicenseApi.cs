using System.Threading.Tasks;
using Incontrl.Net.Abstractions;

namespace Incontrl.Net.Services
{
    internal class LicenseApi : ILicenseApi
    {
        private readonly ClientBase _clientBase;

        public LicenseApi(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<string> GetAsync() => (await _clientBase.GetAsync<string>("license"));
    }
}
