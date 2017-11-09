using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentListFilter
    {
        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DocumentStatus? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RecipientCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? RecipientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid[] TypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentCode { get; set; }
    }
}
