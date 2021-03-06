﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class AppApi : IAppApi
    {
        private readonly ClientBase _clientBase;

        public AppApi(Func<ClientBase> clientBaseFactory) => _clientBase = clientBaseFactory();

        public string AppId { get; set; }

        public Task<App> GetAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.GetAsync<App>($"api/apps/{AppId}", cancellationToken);
    }
}
