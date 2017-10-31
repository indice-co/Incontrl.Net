namespace Incontrl.Sdk.Models
{
    public class Tax
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public bool Inclusive { get; set; }
        public bool IsSalesTax { get; set; }
        public decimal Amount { get; set; }
    }
}
