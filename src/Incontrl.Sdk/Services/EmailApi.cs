using System;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;

namespace Incontrl.Sdk.Services
{
    internal class EmailApi : IEmailApi
    {
        private readonly ClientBase _clientBase;

        public EmailApi(Func<ClientBase> clientBaseFactory) => _clientBase = clientBaseFactory();

        public Task SendAsync(EmailRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
            _clientBase.PostAsync<EmailRequest, object>($"email", request, cancellationToken);
    }
}
