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

        /// <summary>
        /// The date that the document was created.
        /// </summary>
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// The due date of the document.
        /// </summary>
        public DateTimeOffset? DueDate { get; set; }

        public Period Period { get; set; }

        /// <summary>
        /// The current status of the document.
        /// </summary>
        public DocumentStatus? Status { get; set; }

        /// <summary>
        /// The currency code that is used in the document.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The rate of the currency. Defaults to 1.
        /// </summary>
        public double? CurrencyRate { get; set; } = 1;

        /// <summary>
        /// Information about the recipient of the document.
        /// </summary>
        public Recipient Recipient { get; set; }

        /// <summary>
        /// A payment code for the document.
        /// </summary>
        public string PaymentCode { get; set; }

        /// <summary>
        /// The lines of the document.
        /// </summary>
        public virtual DocumentLine[] Lines { get; set; } = new DocumentLine[0];

        /// <summary>
        /// Optional (internal) notes for the document.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Optional (public) notes for the document.
        /// </summary>
        public string PublicNotes { get; set; }

        /// <summary>
        /// Tags that describe the document.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// A permalink that displays the document as a web page.
        /// </summary>
        public string PermaLink { get; }

        public decimal? SubTotal { get; set; }
        public decimal? TotalNet { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalSalesTax { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? Total { get; set; }

        /// <summary>
        /// The total payable of the document.
        /// </summary>
        public decimal? TotalPayable { get; set; }
    }
}
