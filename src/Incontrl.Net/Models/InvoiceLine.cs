using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Incontrl.Net.Models
{
    public class InvoiceLine
    {
        /// <summary>
        /// Line Id.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Associated product with the invoice line.
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
        /// Total tax on invoice LINE.
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Total Sales tax on invoice LINE.
        /// </summary>
        public decimal TotalSalesTax { get; set; }

        /// <summary>
        /// Total of invoice LINE (SubTotal + TotalTax).
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Item taxes - NOT SALES TAX (aka VAT) other inclusive or exclusive taxes.
        /// </summary>
        public ICollection<Tax> Taxes { get; set; } = new List<Tax>();

        [JsonIgnore]
        public string TaxesDescription {
            get => string.Join(", ", Taxes?.Select(x => $"{x.Name} ({x.Rate:#,##0.##%})") ?? new string[0]);
        }

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