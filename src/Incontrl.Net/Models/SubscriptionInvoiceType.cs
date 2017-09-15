using System;
using Newtonsoft.Json;

namespace Incontrl.Net.Models
{
    public class SubscriptionInvoiceType
    {

        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid SubscriptionId { get; set; }

        public string Code { get; set; }
        public RecordType RecordType { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public int NumberOffset { get; set; }
        public string NumberFormat { get; set; }

        [JsonIgnore]
        public Guid? TemplateId { get; set; }

        public Attachment Template { get; set; }

        /// <summary>
        /// Notes for this item.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Tags for this item.
        /// </summary>
        public string Tags { get; set; }

        public bool GeneratesDocuments { get; set; } = true;

        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
