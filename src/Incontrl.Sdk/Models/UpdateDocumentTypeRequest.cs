namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A class that describes the type of a <see cref="Document"/> to update.
    /// </summary>
    public class UpdateDocumentTypeRequest
    {
        /// <summary>
        /// The name of the document type.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Unique short code for the item.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// The default culture of the document type.
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// The offset of the document type.
        /// </summary>
        public int NumberOffset { get; set; }
        /// <summary>
        /// Discriminator for the document type.
        /// </summary>
        public RecordType RecordType { get; set; }
        /// <summary>
        /// The display format of the document type's number.
        /// </summary>
        public string NumberFormat { get; set; }
        /// <summary>
        /// Optional tags for the document type.
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// Notes for the document type.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Specifies if this document type can generate documents. Defaults to true.
        /// </summary>
        public bool GeneratesDocuments { get; set; }
        /// <summary>
        /// Specifies whether the documents associated with this type are public or not. Defaults to true.
        /// </summary>
        public bool IsPublic { get; set; }
        /// <summary>
        /// Public comments that are rendered by default for this document type.
        /// </summary>
        public string DefaultPublicComments { get; set; }
        /// <summary>
        /// Specifies the classification used by AADE.
        /// </summary>
        public string Classification { get; set; }
    }
}
