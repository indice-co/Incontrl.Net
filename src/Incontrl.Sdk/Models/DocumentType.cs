using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentType
    {
        /// <summary>
        /// The unique identifier for the document type.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Discrimination between.
        /// </summary>
        public RecordType RecordType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOffset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumberFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Attachment Template { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool GeneratesDocuments { get; set; } = true;
    }
}
