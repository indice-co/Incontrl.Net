using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class DocumentLine
    {
        /// <summary>
        /// Line Id.
        /// </summary>
        public Guid? Id { get; set; }
        /// <summary>
        /// Associated product with the document line.
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// Line Description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Line Quantity.
        /// </summary>
        public double Quantity { get; set; } = 1;
        /// <summary>
        /// Line unit amount. By default, unit amount will be rounded to two decimal places.
        /// </summary>
        public decimal UnitAmount { get; set; }
        /// <summary>
        /// Discount rate for this item.
        /// </summary>
        public double DiscountRate { get; set; }
        /// <summary>
        /// Total for line item EXCLUDING taxes.
        /// </summary>
        public decimal SubTotal { get; set; }
        /// <summary>
        /// Total tax on document line.
        /// </summary>
        public decimal TotalTax { get; set; }
        /// <summary>
        /// Total Sales tax on document line.
        /// </summary>
        public decimal TotalSalesTax { get; set; }
        /// <summary>
        /// Total of document line (SubTotal + TotalTax).
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Item taxes - NOT SALES TAX (aka VAT) other inclusive or exclusive taxes.
        /// </summary>
        public ICollection<TaxAmount> Taxes { get; set; } = new List<TaxAmount>();
        /// <summary>
        /// Notes for this item.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Tags for this item.
        /// </summary>
        public string Tags { get; set; }
    }
}
