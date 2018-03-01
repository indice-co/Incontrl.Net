namespace Incontrl.Sdk.Models
{
    public class UpdateDocumentStatusRequest
    {
        public DocumentStatus Status { get; set; }
        public bool Force { get; set; }
    }
}
