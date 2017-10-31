namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Metrics
    {
        /// <summary>
        /// 
        /// </summary>
        public int Requests { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RequestsPerMinute { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Writes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Reads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Documents { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public enum Type
        {
            Requests, RequestsPerMinute, Writes, Reads, Documents
        }
    }
}
