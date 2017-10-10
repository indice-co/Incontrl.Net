using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Models;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceInvoiceTypeApi
    {
        string SubscriptionId { get; set; }
        string InvoiceId { get; set; }

        Task<InvoiceType> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<InvoiceType> UpdateAsync(UpdateInvoiceTypeRequest type, CancellationToken cancellationToken = default(CancellationToken));
    }
}
