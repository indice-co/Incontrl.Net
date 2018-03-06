using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A class that describes an address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// A unique id for the address.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// A Name for the address.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address line 1.
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// Address line 2.
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Country ISO code.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Country info.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Phone1.
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone2.
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Notes for the address..
        /// </summary>
        public string Notes { get; set; }

        public override string ToString() => Name ?? $"{Line1}, {ZipCode}, {City} {Country}".TrimEnd(' ', ',');

        public string ResolveLine1() {
            var line = $"{Line1} {City}".TrimEnd(' ', ',');
            return string.IsNullOrWhiteSpace(line) ? null : line;
        }

        public string ResolveLine2() {
            var line = $"{Line2} {ZipCode}, {Country}".Trim(' ', ',');
            return string.IsNullOrWhiteSpace(line) ? null : line;
        }
    }
}
