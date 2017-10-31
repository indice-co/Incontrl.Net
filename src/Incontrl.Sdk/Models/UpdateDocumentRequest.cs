using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Message  to update an existing document.
    /// </summary>
    public class UpdateDocumentRequest
    {
        public DateTimeOffset? Date { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public string CurrencyCode { get; set; }
        public double? CurrencyRate { get; set; }
        public Recipient Recipient { get; set; }
        public string PaymentCode { get; set; }
        public DocumentLine[] Lines { get; set; }
        public bool ServerCalculations { get; set; } = true;
        public string Notes { get; set; }
        public string PublicNotes { get; set; }
        public string Tags { get; set; }

        //******************************************************************************
        // Totals (amounts)
        //******************************************************************************
        /// <summary>
        /// Total net amount excluding taxes.
        /// </summary>
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// Total sales tax amount.
        /// </summary>
        public decimal? TotalSalesTax { get; set; }

        /// <summary>
        /// Total tax amount.
        /// </summary>
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// Total amount for document (SubTotal + TotalTax).
        /// </summary>
        public decimal? Total { get; set; }

        /// <summary>
        /// Total amount for document (SubTotal + TotalTax).
        /// </summary>
        public decimal? TotalPayable { get; set; }
    }
}
