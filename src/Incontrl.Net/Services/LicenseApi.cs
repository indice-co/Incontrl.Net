﻿using System.Threading.Tasks;
using Incontrl.Net.Abstractions;
using Incontrl.Net.Http;

namespace Incontrl.Net.Services
{
    internal class LicenseApi : ILicenseApi
    {
        private ClientBase _clientBase;

        public LicenseApi(ClientBase clientBase) => _clientBase = clientBase;

        public async Task<string> GetAsync() => (await _clientBase.GetAsync<string>("license"));
    }
}