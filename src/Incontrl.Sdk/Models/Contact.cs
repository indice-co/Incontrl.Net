using System;

namespace Incontrl.Sdk.Models
{
    public class Contact
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }

        /// <summary>
        /// First name of contact person (max length = 255).
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of contact person (max length = 255).
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Email address of contact person (umlauts not supported) (max length = 255)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Primary address of the organisation.
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
        /// Skype user name of contact.
        /// </summary>
        public string Skype { get; set; }

        /// <summary>
        /// Notes for the contact (max length 500).
        /// </summary>
        public string Notes { get; set; }
    }
}
