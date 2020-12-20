namespace Incontrl.Sdk.Models
{
    public class TaxAmount : Tax
    {
        public TaxAmount() { }

        public TaxAmount(Tax tax) {
            Id = tax.Id;
            Type = tax.Type;
            Code = tax.Code;
            Name = tax.Name;
            Rate = tax.Rate;
            Inclusive = tax.Inclusive;
            IsSalesTax = tax.IsSalesTax;
            IncursSalesTax = tax.IncursSalesTax;
            Translations = tax.Translations;
            Classification = tax.Classification;
        }

        public decimal Amount { get; set; }

        public Tax ToTax() => new Tax {
            Id = Id,
            Type = Type,
            Code = Code,
            Name = Name,
            Rate = Rate,
            Inclusive = Inclusive,
            IsSalesTax = IsSalesTax,
            IncursSalesTax = IncursSalesTax,
            Translations = Translations,
            Classification = Classification
        };
    }
}
