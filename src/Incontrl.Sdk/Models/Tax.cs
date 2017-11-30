namespace Incontrl.Sdk.Models
{
    public class Tax
    {
        public TaxType Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public bool Inclusive { get; set; }
        public bool IsSalesTax { get; set; }
    }

    public enum TaxType : short
    {
        UnitRate = 0,
        FixedRate,
        Fixed
    }
}
