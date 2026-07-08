using System;

namespace Incontrl.Sdk.Models
{
    public class Payment
    {
        public Guid? Id { get; set; }
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
        public Transaction Transaction { get; set; }
        public Money Value { get; set; }
        public string Comments { get; set; }
        /// <summary>
        /// The date of the payment.
        /// </summary>
        public DateTimeOffset Date { get; set; }
        /// <summary>
        /// When the payment was last modified.
        /// </summary>
        public DateTimeOffset? LastModified { get; set; }
        /// <summary>
        /// The approval state of the payment.
        /// </summary>
        public ApprovalStatus State { get; set; }
        /// <summary>
        /// External reference number for the payment.
        /// </summary>
        public string ReferenceNumber { get; set; }
    }
}
