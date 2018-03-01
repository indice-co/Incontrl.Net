using System;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;

namespace Incontrl.Sdk.Services
{
    internal class LicenseApi : ILicenseApi
    {
        private readonly ClientBase _clientBase;

        public LicenseApi(Func<ClientBase> clientBaseFactory) => _clientBase = clientBaseFactory();

        public async Task<string> GetAsync() => (await _clientBase.GetAsync<string>($"license"));
    }
}
