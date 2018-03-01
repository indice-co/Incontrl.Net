using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Incontrl.Sdk.Types;

namespace Incontrl.Sdk.Services
{
    internal class GlobalPaymentOptionsApi : IGlobalPaymentOptionsApi
    {
        private readonly ClientBase _clientBase;

        public GlobalPaymentOptionsApi(ClientBase clientBase) => _clientBase = clientBase;

        public Task<ResultSet<PaymentOption>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) => 
            _clientBase.GetAsync<ResultSet<PaymentOption>>("subscriptions/all/payment-options", options, cancellationToken);
    }
}
