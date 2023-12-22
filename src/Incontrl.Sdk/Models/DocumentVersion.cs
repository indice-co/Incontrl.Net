using System;

namespace Incontrl.Sdk.Models
{
    public class DocumentVersion
    {
        public Guid Id { get; set; }
        public DocumentStatus StatusFrom { get; set; }
        public DocumentStatus StatusTo { get; set; }
        public string Operation { get; set; }
        public string Mark { get; set; }
        public string Uuid { get; set; }
        public string QrCodeUrl { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
        public string CreatedBy { get; set; }
    }
}
