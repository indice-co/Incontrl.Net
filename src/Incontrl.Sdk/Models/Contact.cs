using System;

namespace Incontrl.Sdk.Models
{
    public class Contact
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Skype { get; set; }
        public string Notes { get; set; }
        public object CustomData { get; set; }

        public string ResolveDisplayName() {
            var fullName = $"{FirstName} {LastName}".Trim();

            if (string.IsNullOrWhiteSpace(fullName)) {
                fullName = null;
            }

            var displayName = DisplayName ?? fullName ?? Email;
            return displayName;
        }

        public override string ToString() => ResolveDisplayName() ?? base.ToString();
    }
}
