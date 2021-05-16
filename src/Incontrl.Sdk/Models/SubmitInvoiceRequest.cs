using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Models the request to AADE when submitting an invoice.
    /// </summary>
    public class SubmitInvoiceRequest
    {
        /// <summary>
        /// Related invoices.
        /// </summary>
        public Guid[] RelatedDocumentIds { get; set; }
        /// <summary>
        /// Invoice payments.
        /// </summary>
        public SubmitInvoicePaymentRequest[] Payments { get; set; }
        /// <summary>
        /// An optional branch code.
        /// </summary>
        public int? BranchCode { get; set; }
    }

    /// <summary>
    /// Models an invoice payment.
    /// </summary>
    public class SubmitInvoicePaymentRequest
    {
        /// <summary>
        /// Payment classification.
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// Payment amount.
        /// </summary>
        public Money Amount { get; set; }
    }
}
