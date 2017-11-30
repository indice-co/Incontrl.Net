namespace Incontrl.Sdk.Models
{
    public class TaxAmount : Tax
    {
        public decimal Amount { get; set; }

        public Tax ToTax() {
            return new Tax {
                Type = Type,
                Code = Code,
                Name = Name,
                Inclusive = Inclusive,
                IsSalesTax = IsSalesTax
            };
        }
    }
}
