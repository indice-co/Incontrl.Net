using System;

namespace Incontrl.Sdk.Models
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid TypeId { get; set; }
        public int? Number { get; set; }
        public string NumberPrintable { get; set; }
        public DateTimeOffset? Date { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public DocumentStatus? Status { get; set; }
        public string CurrencyCode { get; set; }
        public double? CurrencyRate { get; set; } = 1;
        public Recipient Recipient { get; set; }
        public string PaymentCode { get; set; }
        public DocumentLine[] Lines { get; set; } = new DocumentLine[0];
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
