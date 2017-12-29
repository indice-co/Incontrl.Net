using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class DocumentCalculationRequest
    {
        public string CurrencyCode { get; set; }
        public List<PricedLine> Lines { get; set; }
    }
}
