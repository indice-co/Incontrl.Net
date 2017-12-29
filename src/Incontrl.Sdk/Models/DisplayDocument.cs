using System.Collections.Generic;
using System.Globalization;

namespace Incontrl.Sdk.Models
{
    public class DisplayDocument : Document
    {
        public string Culture { get; set; }
        public Issuer Issuer { get; set; }
        public bool HasLogo { get; set; }
        public string IssuerLogoUrl { get; set; }
        public List<TaxAmount> Taxes { get; set; }
        public List<TaxAmount> TaxesInclusive { get; set; }
        public List<TaxAmount> TaxesExclusive { get; set; }
        public bool HasDiscount { get; set; }
        public bool HasInclusiveSalesTax { get; set; }
        public bool HasDeductables { get; set; }
        public Attachment Printout { get; set; }
        public string TypeName { get; set; }
        public DocumentType Type { get; set; }
        public Dictionary<string, string> Translations { get; set; }
        public string Translate(string name) => Translate(name, null);

        public string Translate(string name, params object[] arguments) {
            var value = Translations.ContainsKey(name) ? Translations[name] : name;

            if (arguments != null) {
                value = string.Format(new CultureInfo(Culture), value, arguments);
            }

            return value;
        }
    }
}
