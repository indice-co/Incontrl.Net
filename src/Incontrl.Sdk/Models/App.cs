using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class App
    {
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string AppUri { get; set; }
        public bool Enabled { get; set; }
        public ICollection<AppKey> Keys { get; set; }
        public ICollection<Webhook> Webhooks { get; set; }
    }

    public class AppKey
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
    }

    public class Webhook
    {
        public string CallbackUri { get; set; }
        public EventType EventType { get; set; }
        public string VerifyToken { get; set; }
    }

    public enum EventType
    {
        DocumentVoid = 1,
        DocumentPaid,
        DocumentIssued,
        DocumentOverdue,
        DocumentReconciled,
        DocumentPartiallyReconciled,
        DocumentDeleted
    }
}
