namespace Incontrl.Net.Models
{
    public enum SubscriptionStatus
    {
        Enabled = 1,
        Disabled = 2,
        Deleted = 3
    }

    public class SubscriptionStatusInfo {
        public string Id { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}