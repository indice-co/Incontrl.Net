using System;

namespace Incontrl.Sdk.Models
{
    public class Tracker
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string DocumentUrl { get; set; }
    }

    public class DocumentTracking
    {
        public int Reads { get; set; }
        public string Recipient { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastRead { get; set; }
    }

    public class UpdateDocumentTrackingRequest
    {
        public int Reads { get; set; }
        public DateTime? LastRead { get; set; }
    }
}
