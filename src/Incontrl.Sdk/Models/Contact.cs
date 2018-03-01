using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A class that describes a contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// The id of the contact.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// A field used as correlation key.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The display name of the contact.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// First name of contact person (max length = 255)
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of contact person (max length = 255)
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address of contact person (umlauts not supported) (max length = 255)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// primary address of the organisation
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Phone1
        /// </summary>
        public string Phone1 { get; set; }

        /// <summary>
        /// Phone2
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        /// Skype user name of contact
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// Notes for the contact (max length 500)
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Custom data for this subscription.
        /// </summary>
        public object CustomData { get; set; }

        /// <summary>
        /// Tax identification code (number) of the contact.
        /// </summary>
        public string TaxCode { get; set; }

        /// <summary>
        /// Tax office for the contact.
        /// </summary>
        public string TaxOffice { get; set; }
    }
}
