using System;
using Newtonsoft.Json;

namespace Incontrl.Net.Models
{
    public class Attachment
    {
        public Attachment() {
            Id = Guid.NewGuid();
            Guid = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [JsonIgnore]
        public Guid SubscriptionId { get; set; }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string FileExtension { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public byte[] Data { get; set; }

        public string Uri {
            get => $"{SubscriptionId}/{Guid.ToString("N").Substring(0, 2)}/{Guid:N}{FileExtension}";
        }
    }
}
