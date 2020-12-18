using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class SubmitInvoiceRequest
    {
        public Guid[] RelatedDocumentIds { get; set; }
        public IEnumerable<SubmitInvoicePaymentRequest> Payments { get; set; } = new List<SubmitInvoicePaymentRequest>();
    }

    public class SubmitInvoicePaymentRequest
    {
        public string Classification { get; set; }
        public Money Amount { get; set; }
    }
}
