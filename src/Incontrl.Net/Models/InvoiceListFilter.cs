using System;

namespace Incontrl.Net.Models
{
    public class InvoiceListFilter
    {
        public string Number { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public StatusOfInvoice? Status { get; set; }
        public string RecipientCode { get; set; }
        public Guid? RecipientId { get; set; }
        public Guid? TypeId { get; set; }
    }
}