namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Models a request to update a service.
    /// </summary>
    public class UpdateServiceRequest
    {
        /// <summary>
        /// Specifies whether to enable or disable the service.
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// The configuration of the service.
        /// </summary>
        public dynamic Settings { get; set; }
    }
}
