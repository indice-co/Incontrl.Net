namespace Incontrl.Sdk.Models
{
    public class PaymentOption
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PaymentOptionType Type { get; set; }
    }
}
