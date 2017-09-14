using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Incontrl.Net.Models
{
    public class Product
    {
        /// <summary>
        /// Unique identifier for the item.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Owner subscription.
        /// </summary>
        [JsonIgnore]
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Unique short code for the item.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of the product.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Backing store for the taxes collection (serialized json).
        /// </summary>
        [JsonIgnore]
        public string TaxesJson {
            get => Taxes != null ? JsonConvert.SerializeObject(Taxes) : null;
            set => Taxes = value != null ? JsonConvert.DeserializeObject<ICollection<Tax>>(value) : null;
        }

        /// <summary>
        /// Item taxes - NOT SALES TAX (aka VAT) other inclusive or exclusive taxes
        /// </summary>
        public ICollection<Tax> Taxes { get; set; } = new List<Tax>();

        /// <summary>
        /// Notes for this item.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Notes for this item.
        /// </summary>
        public string PublicNotes { get; set; }

        /// <summary>
        /// Tags for this item.
        /// </summary>
        public string Tags { get; set; }
    }
}