namespace Incontrl.Sdk.Models
{
    public class CurrencyInfo
    {
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Symbol { get; set; }
        public bool AlignRight { get; set; }

        /// <summary>
        /// This is a common currency among countries or not.
        /// </summary>
        public bool IsCommon { get; set; }

        /// <summary>
        /// Three letter iso symbol.
        /// </summary>
        public string ISOSymbol { get; set; }

        public FractionInfo Fraction { get; set; }
    }
}
