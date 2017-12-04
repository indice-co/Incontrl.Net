using System;

namespace Incontrl.Sdk.Models
{
    public class PaymentOption
    {
        public Guid? Id { get; set; }
        public Guid? SubscriptionId { get; set; }
        public PaymentOptionType? Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Service Provider { get; set; }
    }
}
