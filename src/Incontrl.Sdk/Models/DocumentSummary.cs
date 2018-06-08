namespace Incontrl.Sdk.Models
{
    public class DocumentSummary
    {
        public string CurrencyCode { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalOtherTax { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal TotalPayable { get; set; }
    }
}
