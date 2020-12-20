using System;

namespace Incontrl.Sdk.Models
{
    public class DocumentListFilter
    {
        public string Code { get; set; }
        public string Number { get; set; }
        public string ParentNumber { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public DateTime? ModifiedFrom { get; set; }
        public DateTime? ModifiedTo { get; set; }
        public DateTime? DueFrom { get; set; }
        public DateTime? DueTo { get; set; }
        public DocumentStatus[] Status { get; set; }
        public RecordType? RecordType { get; set; }
        public string RecipientCode { get; set; }
        public string RecipientName { get; set; }
        public Guid? RecipientId { get; set; }
        public string RecipientOrganizationName { get; set; }
        public string RecipientContactName { get; set; }
        public Guid[] TypeId { get; set; }
        public Guid[] ProductId { get; set; }
        public string CustomerReference { get; set; }
        public string PaymentCode { get; set; }
        public string Title { get; set; }
        public bool IsMarked { get; set; }
        public bool? HasSyncError { get; set; }
    }
}
