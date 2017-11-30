using System;

namespace Incontrl.Sdk.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Class { get; set; }
        public bool Enabled { get; set; }
        public UiHint UiHint { get; set; }
        public dynamic Settings { get; set; }
        public dynamic SettingsSchema { get; set; }
        public ServiceType Type { get; set; }
    }

    public enum ServiceType
    {
        Reconciliation = 1,
        WebHooks,
        PaymentOption,
        Trial
    }
}
