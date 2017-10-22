using System;

namespace Incontrl.Net.Models
{
    public class Payment
    {
        public Guid? Id { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? TransactionId { get; set; }
        public ApprovalStatus Approval { get; set; }
        public decimal? Amount { get; set; }
        public string Comments { get; set; }
    }
}
