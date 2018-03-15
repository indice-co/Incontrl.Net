namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// An object that represents a request for sending an email message.
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// The list of recipient(s) to receive the email message.
        /// </summary>
        public string[] Recipients { get; set; } = new string[] { };

        /// <summary>
        /// The subject of the email message.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The content of the email message.
        /// </summary>
        public string Body { get; set; }
    }
}
