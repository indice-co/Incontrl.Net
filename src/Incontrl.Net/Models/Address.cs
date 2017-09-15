namespace Incontrl.Net.Models
{
    public class Address
    {
        /// <summary>
        /// A Name for the address.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// AddressLine 1 (max length = 500).
        /// </summary>
        public string Line1 { get; set; }

        /// <summary>
        /// AddressLine 2 (max length = 500).
        /// </summary>
        public string Line2 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Country ISO code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Country info.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Phone1
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone2
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Notes for the address (max length 500).
        /// </summary>
        public string Notes { get; set; }
    }
}
