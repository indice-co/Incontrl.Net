using System;

namespace Incontrl.Sdk.Models
{
    public class TaxDefinition
    {
        public Guid? Id { get; set; }
        public TaxType Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public bool IsSalesTax { get; set; }
        public bool IncursSalesTax { get; set; }
        public string DisplayName { get; set; }
    }

    public enum TaxType : short
    {
        UnitRate = 0,
        FixedRate,
        Fixed
    }
}
