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
        /// The number of the document.
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// The number of the document in a printable format.
        /// </summary>
        public string NumberPrintable { get; set; }

        /// <summary>
        /// The date that the document was created.
        /// </summary>
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// The due date of the document.
        /// </summary>
        public DateTimeOffset? DueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// The sub total of the document (UnitAmounts * Quantities).
        /// </summary>
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// The total discount applied to the document.
        /// </summary>
        public decimal? TotalDiscount { get; set; }

        /// <summary>
        /// The total net (without taxes) of the document.
        /// </summary>
        public decimal? TotalNet { get; set; }

        /// <summary>
        /// The total amount of sales taxes (e.x VAT).
        /// </summary>
        public decimal? TotalSalesTax { get; set; }

        /// <summary>
        /// The total amount of taxes (other than sales taxes).
        /// </summary>
        public decimal? TotalOtherTax { get; set; }

        /// <summary>
        /// The total amount of taxes.
        /// </summary>
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// The total of the document.
        /// </summary>
        public decimal? Total { get; set; }

        /// <summary>
        /// The total payable of the document.
        /// </summary>
        public decimal? TotalPayable { get; set; }

        /// <summary>
        /// The type of the document.
        /// </summary>
        public DocumentType Type { get; set; }

        /// <summary>
        /// Total amount performed by children.
        /// </summary>
        public decimal? Fulfilled { get; set; }

        /// <summary>
        /// Progress as a rate of parent document total net and chlidren's total net.
        /// </summary>
        public decimal? Progress { get; set; }
    }
}
