﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// A class that describes the type of a <see cref="Document"/>.
    /// </summary>
    public class DocumentType : DocumentTypeBase
    {
        /// <summary>
        /// Unique short code for the item.
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// The alias (a human friendly id) of the document type.
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// The default culture of the document type.
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// The offset of the document type.
        /// </summary>
        public int NumberOffset { get; set; }
        /// <summary>
        /// The display format of the document type's number.
        /// </summary>
        public string NumberFormat { get; set; }
        /// <summary>
        /// Optional information to display the document type.
        /// </summary>
        public UiHint UiHint { get; set; }
        /// <summary>
        /// The template document that accompanies this type.
        /// </summary>
        public Attachment Template { get; set; }
        /// <summary>
        /// Notes for the document type.
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Optional tags for the document type.
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// Specifies if this document type can generate documents. Defaults to true.
        /// </summary>
        public bool GeneratesDocuments { get; set; }
        /// <summary>
        /// Related payment options.
        /// </summary>
        public List<PaymentOption> PaymentOptions { get; set; }
        /// <summary>
        /// Item translations in various locales.
        /// </summary>
        public TranslationDictionary<DocumentTypeTranslation> Translations { get; set; }
        /// <summary>
        /// Specifies whether the documents associated with this type are public or not. Defaults to true.
        /// </summary>
        public bool IsPublic { get; set; }
        /// <summary>
        /// Public comments that are rendered by default for this document type.
        /// </summary>
        public string DefaultPublicComments { get; set; }
        /// <summary>
        /// Gets payment options used for displaying bank account information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentOption> GetPaymentInfos() => (PaymentOptions ?? new List<PaymentOption>()).Where(x => x.Type == PaymentOptionType.Info);
        /// <summary>
        /// Gets payment options to pay online through a payment gateway provider like Paypal, a bank wallet or a bank e-commerce integration.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentOption> GetPaymentGateways() => (PaymentOptions ?? new List<PaymentOption>()).Where(x => x.Type == PaymentOptionType.PISP && x.Provider?.Class != null && x.Provider.Enabled);
        /// <summary>
        /// Specifies the classification used by AADE.
        /// </summary>
        public string Classification { get; set; }
    }

    /// <summary>
    /// Basic info for a document type.
    /// </summary>
    public class DocumentTypeBase
    {
        /// <summary>
        /// A unique identifier for the item.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// The name of the document type.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The category of document type.
        /// </summary>
        public RecordType RecordType { get; set; }
    }
}
