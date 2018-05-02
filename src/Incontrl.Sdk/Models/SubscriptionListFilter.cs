namespace Incontrl.Sdk.Models
{
    public class SubscriptionListFilter
    {
        public string Code { get; set; }
        public string MemberId { get; set; }
        public bool WithAisp { get; set; }
        public SubscriptionStatus? Status { get; set; }
    }
}
