using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class DocumentCalculationResult
    {
        public List<PricedLineResult> Lines { get; set; }
        public List<TaxAmount> Taxes { get; set; }
        public List<TaxAmount> TaxesInclusive { get; set; }
        public List<TaxAmount> TaxesExclusive { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal TotalOtherTax { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPayable { get; set; }
    }
}
