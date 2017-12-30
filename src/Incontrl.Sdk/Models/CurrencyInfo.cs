using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incontrl.Sdk.Models
{

    public class CurrencyInfo : IFormatProvider, ICustomFormatter
    {
        public class FractionInfo
        {   
            public string Name { get; set; }
            public string Symbol { get; set; }
            public int Denominator { get; set; }
            public int DecimalPlaces => (int)Math.Log10(Denominator);
            public override string ToString() {
                return string.Format("{0} ({1})", Name, Symbol, Denominator);
            }
        }

        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Symbol { get; set; }
        public bool AlignRight { get; set; }

        /// <summary>
        /// Three letter iso symbol.
        /// </summary>
        public string ISOSymbol { get; set; }
        public FractionInfo Fraction { get; set; }
        public override string ToString() {
            return $"{ISOSymbol} - {Name} ({Symbol}), {Fraction}";
        }

        public string Format(string format, object arg, IFormatProvider formatProvider) {
            if (arg is double || arg is decimal || arg is int || arg is long || arg is short) {
                var numberFormatInfo = (NumberFormatInfo)GetFormat(typeof(NumberFormatInfo));
                if (string.IsNullOrEmpty(format)) {
                    // by default, format doubles to 3 decimal places
                    return string.Format(numberFormatInfo, "C", arg);
                } else {
                    // if user supplied own format use it
                    return ((double)arg).ToString(format, numberFormatInfo);
                }
            }
            // format everything else normally
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, formatProvider);
            else
                return arg.ToString();
        }

        public object GetFormat(Type formatType) {
            if (formatType == typeof(ICustomFormatter)) {
                return this;
            } else if (formatType == typeof(NumberFormatInfo)) {
                var rtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft;
                var numberFormatInfo = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
                numberFormatInfo.CurrencySymbol = Symbol; // Replace with "$" or "£" or whatever you need

                var positiveLeftPattern = !rtl ? 2 : 3; // https://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencynegativepattern(v=vs.110).aspx
                var positiveRightPattern = !rtl ? 3 : 2;
                var negativeLeftPattern = !rtl ? 14 : 15; //https://msdn.microsoft.com/en-us/library/system.globalization.numberformatinfo.currencynegativepattern(v=vs.110).aspx
                var negativeRightPattern = !rtl ? 8 : 11;

                numberFormatInfo.CurrencyPositivePattern = AlignRight ? positiveRightPattern : positiveLeftPattern;
                numberFormatInfo.CurrencyNegativePattern = AlignRight ? negativeRightPattern : negativeLeftPattern;
                return numberFormatInfo;
            }

            return null;
        }

        public decimal Round(decimal money) {
            return Math.Round(money, Fraction?.DecimalPlaces ?? 2);
        }
    }
}
