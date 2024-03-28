using System.Threading;
using System.Threading.Tasks;
using Incontrl.Sdk.Abstractions;
using Incontrl.Sdk.Models;
using Indice.Types;

namespace Incontrl.Sdk.Services
{
    internal class GlobalPaymentOptionsApi(ClientBase clientBase) : IGlobalPaymentOptionsApi
    {
        public Task<ResultSet<PaymentOption>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default) => 
            clientBase.GetAsync<ResultSet<PaymentOption>>("subscriptions/all/payment-options", options, cancellationToken);
    }
}
