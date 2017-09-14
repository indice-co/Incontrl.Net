using System;

namespace Incontrl.Net.Models
{
    public class InvoiceStatus
    {
        public Guid Id { get; set; }
        public StatusOfInvoice Status { get; set; }
    }
}