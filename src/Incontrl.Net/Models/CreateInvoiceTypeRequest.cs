namespace Incontrl.Net.Models
{
    public class CreateInvoiceTypeRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Culture { get; set; }
        public int NumberOffset { get; set; }
        public RecordType RecordType { get; set; }
        public string NumberFormat { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public bool GeneratesDocuments { get; set; } = true;
    }
}
