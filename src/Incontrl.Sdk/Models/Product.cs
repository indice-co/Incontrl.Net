using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class Product
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public List<Tax> Taxes { get; set; }
        public string Notes { get; set; }
        public string PublicNotes { get; set; }
        public string Tags { get; set; }
    }
}
