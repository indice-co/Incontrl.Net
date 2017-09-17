namespace Incontrl.Net.Models
{
    public class Currency
    {
        public string Name { get; protected set; }
        public string NativeName { get; protected set; }
        public string Symbol { get; protected set; }

        /// <summary>
        /// Three letter ISO symbol.
        /// </summary>
        public string ISOSymbol { get; protected set; }

        public Fraction Fraction { get; protected set; }
    }

    public class Fraction
    {
        public Fraction(string name, string symbol, int denominator) {
            Name = name;
            Symbol = symbol;
            Denominator = denominator;
        }

        public string Name { get; protected set; }
        public string Symbol { get; protected set; }
        public int Denominator { get; protected set; }
    }
}
