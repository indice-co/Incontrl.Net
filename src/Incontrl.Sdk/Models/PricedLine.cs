using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class PricedLine
    {
        public Guid Id { get; set; }
        public double Quantity { get; set; }
        public decimal UnitAmount { get; set; }
        public double DiscountRate { get; set; }
        public List<Tax> Taxes { get; set; }
        public string TaxesDescription { get; set; }
    }
}
