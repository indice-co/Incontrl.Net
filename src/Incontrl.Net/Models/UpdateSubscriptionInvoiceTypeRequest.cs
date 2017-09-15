namespace Incontrl.Net.Models
{
    public class UpdateSubscriptionInvoiceTypeRequest
    {
        const string DEFAULT_NUMBERFORMAT = "{0}";
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Culture { get; set; }
        public int NumberOffset { get; set; }
        public RecordType RecordType { get; set; }
        public string NumberFormat { get; set; }
        public string Tags { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool GeneratesDocuments { get; set; } = true;
    }
}
