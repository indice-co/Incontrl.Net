﻿using System.Threading;
using System.Threading.Tasks;
using Incontrl.Net.Http;
using Incontrl.Net.Models;
using Incontrl.Net.Types;

namespace Incontrl.Net.Abstractions
{
    public interface IInvoiceTypesApi
    {
        string SubscriptionId { get; set; }
        Task<InvoiceType> CreateAsync(CreateInvoiceTypeRequest invoiceType, CancellationToken cancellationToken = default(CancellationToken));
        Task<ResultSet<InvoiceType>> ListAsync(ListOptions options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}