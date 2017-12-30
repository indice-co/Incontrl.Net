using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class DocumentLine
    {
        public Guid? Id { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public decimal UnitAmountNet { get; set; }
        public decimal UnitAmount { get; set; }
        public double DiscountRate { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalSalesTax { get; set; }
        public decimal Total { get; set; }
        public List<TaxAmount> Taxes { get; set; } = new List<TaxAmount>();
        public string TaxesDescription { get; set; }
        public string Notes { get; set; }
        public string Tags { get; set; }
    }
}
