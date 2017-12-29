using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class PricedLineResult : PricedLine
    {
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal Total { get; set; }
        public new List<TaxAmount> Taxes { get; set; }
    }
}
