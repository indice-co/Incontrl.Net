namespace Incontrl.Sdk.Models
{
    public class UpdateContactRequest
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Skype { get; set; }
        public string Notes { get; set; }
    }
}
