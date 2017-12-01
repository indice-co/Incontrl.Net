namespace Incontrl.Sdk.Models
{
    public class WebhookFilter
    {
        public EventType? Event { get; set; }
        public string[] AppIds { get; set; } = new string[0];
    }
}
