using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A class that describes a document.
    /// </summary>
    public class Document
    {
        /// <summary>
        /// The unique id of the document.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// A correlation key for the document.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The type of the document.
        /// </summary>
        public DocumentType Type { get; set; }

        /// <summary>
        /// The number of the document.
        /// </summary>
        public int? Number { get; set; }

        public string NumberPrintable { get; set; }
        public DateTimeOffset? Date { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public Period Period { get; set; }
        public DocumentStatus? Status { get; set; }
        public string CurrencyCode { get; set; }
        public double? CurrencyRate { get; set; } = 1;
        public Recipient Recipient { get; set; }
        public string PaymentCode { get; set; }

        /// <summary>
        /// The lines of the document.
        /// </summary>
        public virtual DocumentLine[] Lines { get; set; } = new DocumentLine[0];

        public string Notes { get; set; }
        public string PublicNotes { get; set; }
        public string Tags { get; set; }
        public string PermaLink { get; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalNet { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalSalesTax { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalPayable { get; set; }
    }
}
