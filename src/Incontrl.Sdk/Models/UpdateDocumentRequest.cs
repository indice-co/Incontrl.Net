using System;

namespace Incontrl.Sdk.Models
{
    public class UpdateDocumentRequest
    {
        public int? Number { get; set; }
        public DateTimeOffset? Date { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public string CurrencyCode { get; set; }
        public double? CurrencyRate { get; set; }
        public Recipient Recipient { get; set; }
        public string PaymentCode { get; set; }
        public DocumentLine[] Lines { get; set; }
        public bool? ServerCalculations { get; set; }
        public string Notes { get; set; }
        public string PublicNotes { get; set; }
        public string Tags { get; set; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? TotalSalesTax { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalPayable { get; set; }
    }
}
