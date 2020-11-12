using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A class that describes the line of a <see cref="Document"/>.
    /// </summary>
    public class DocumentLine
    {
        /// <summary>
        /// The unique id of the line.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// The product that may be associated with the line.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// The description of the line.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The quantity of the product/service in the line.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// The net amount of the unit in the line.
        /// </summary>
        public decimal UnitAmountNet { get; set; }

        /// <summary>
        /// The gross amount of the unit in the line.
        /// </summary>
        public decimal UnitAmount { get; set; }

        /// <summary>
        /// The discount as a rate.
        /// </summary>
        public double DiscountRate { get; set; }

        public decimal Discount { get; set; }

        /// <summary>
        /// The type of the discount.
        /// </summary>
        public DiscountType DiscountType { get; set; }

        public decimal SubTotal { get; set; }
        public decimal TotalNet { get; set; }

        /// <summary>
        /// The total amount of other taxes in the line.
        /// </summary>
        public decimal TotalOtherTax { get; set; }

        /// <summary>
        /// The total amount of taxes in the line.
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// The total amount of sales taxes in the line.
        /// </summary>
        public decimal TotalSalesTax { get; set; }

        /// <summary>
        /// The gross total of the line.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// The list of taxes that are applied in the line.
        /// </summary>
        public List<TaxAmount> Taxes { get; set; } = new List<TaxAmount>();

        /// <summary>
        /// The taxes that are applied in the line, as a text.
        /// </summary>
        public string TaxesDescription { get; set; }

        /// <summary>
        /// Notes that accompany the line.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Tags that accompany the line.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Classification
        /// </summary>
        public string Classification { get; set; }
    }

    /// <summary>
    /// The type of the discount on the line.
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// Discount as rate.
        /// </summary>
        Rate,

        /// <summary>
        /// Discount as a fixed amount.
        /// </summary>
        Fixed
    }
}
