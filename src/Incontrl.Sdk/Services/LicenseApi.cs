using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class LicenseApi : ILicenseApi
    {
        private readonly ClientBase _clientBase;

        public LicenseApi(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<string> GetAsync() => (await _clientBase.GetAsync<string>($"{_clientBase.ApiAddress}license"));
    }
}
