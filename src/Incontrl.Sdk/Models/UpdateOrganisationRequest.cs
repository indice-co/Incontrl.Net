namespace Incontrl.Sdk.Models
{
    public class UpdateOrganisationRequest
    {
        private object _customData;
        /// <summary>
        /// Short code for the organisation (max length 6).
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// URL to the organisation's logo (max length 255).
        /// </summary>
        public string LogoPath { get; set; }
        /// <summary>
        /// Name (display name) of the organisation.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The legal name of the organisation.
        /// </summary>
        public string LegalName { get; set; }
        /// <summary>
        /// Line of Business (occupation) of the organisation.
        /// </summary>
        public string LineOfBusiness { get; set; }
        /// <summary>
        /// Tax identification code (number) of the organisation.
        /// </summary>
        public string TaxCode { get; set; }
        /// <summary>
        /// Tax office for the organisation (required in some countries).
        /// </summary>
        public string TaxOffice { get; set; }
        /// <summary>
        /// Default currency code for the organisation.
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Primary address of the organisation
        /// </summary>
        public Address Address { get; set; }
        /// <summary>
        /// Email of the organisation (max length 500).
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Website for the organisation (max length 500).
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// Notes for the organisation (max length 500).
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// additional/custom information for the organisation
        /// </summary>
        public object CustomData {
            get { return _customData; }
            set { _customData = value.ToExpandoObject(); }
        }
    }
}
