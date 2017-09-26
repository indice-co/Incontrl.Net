using System;
using Newtonsoft.Json;

namespace Incontrl.Net.Models
{
    public class TypeOfInvoice
    {
        /// <summary>
        /// The unique identifier for the invoice type.
        /// </summary>
        public Guid Id { get; set; }

        public string Code { get; set; }

        /// <summary>
        /// Discrimination between.
        /// </summary>
        public RecordType RecordType { get; set; }

        public string Name { get; set; }
        public string Culture { get; set; }
        public int NumberOffset { get; set; }
        public string NumberFormat { get; set; }
        public Attachment Template { get; set; }
        public string Notes { get; set; }
        public string Tags { get; set; }
        public bool GeneratesDocuments { get; set; } = true;
    }
}
