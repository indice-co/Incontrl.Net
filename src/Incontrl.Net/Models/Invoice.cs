using System;

namespace Incontrl.Net.Models
{
    public class Invoice
    {
        public Guid? Id { get; set; }
        public Guid? TypeId { get; set; }
        public int? Number { get; set; }
        public string NumberPrintable { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public StatusOfInvoice? Status { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? CurrencyRate { get; set; } = 1;
        public Recipient Recipient { get; set; }
        public string PaymentCode { get; set; }
        public InvoiceLine[] Lines { get; set; } = new InvoiceLine[0];
        public string Notes { get; set; }
        public string PublicNotes { get; set; }
        public string Tags { get; set; }
        public string PermaLink { get => $"/invoices/{Id}"; }
        public decimal? SubTotal { get; set; }
        public decimal? TotalSalesTax { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalPayable { get; set; }
    }
}