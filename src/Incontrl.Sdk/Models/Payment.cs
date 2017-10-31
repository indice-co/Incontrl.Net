using System;

namespace Incontrl.Sdk.Models
{
    public class Payment
    {
        public Guid? Id { get; set; }
        public Document Document { get; set; }
        public Transaction Transaction { get; set; }
        public ApprovalStatus Approval { get; set; }
        public Money Value { get; set; }
        public string Comments { get; set; }
    }
}
