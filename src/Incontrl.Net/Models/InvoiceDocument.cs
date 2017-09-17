using System.Collections.Generic;

namespace Incontrl.Net.Models
{
    public class InvoiceDocument : Invoice
    {
        public string Culture { get; set; }
        public Currency Currency { get; set; }
        public Issuer Issuer { get; set; }
        public string IssuerLogoUrl { get; set; }
        public List<Tax> Taxes { get; set; }
        public List<Tax> TaxesInclusive { get; set; }
        public List<Tax> TaxesExclusive { get; set; }
        public Attachment Document { get; set; }
        public string TypeName { get; set; }
    }
}
