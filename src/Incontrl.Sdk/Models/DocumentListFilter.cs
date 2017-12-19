using System;

namespace Incontrl.Sdk.Models
{
    public class DocumentListFilter
    {
        public string Number { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DocumentStatus? Status { get; set; }
        public string RecipientCode { get; set; }
        public Guid? RecipientId { get; set; }
        public Guid[] TypeId { get; set; }
        public string PaymentCode { get; set; }
    }
}
