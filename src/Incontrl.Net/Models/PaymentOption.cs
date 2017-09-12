namespace Incontrl.Net.Models
{
    public class PaymentOption
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PaymentOptionType Type { get; set; }

        public string ToHtmlLink() {
            if (Type == PaymentOptionType.Online) {
                return $"<a href=\"{Description}\" title=\"Pay through {Name}\">Pay through {Name}</a>";
            }

            return Description;
        }
    }
}