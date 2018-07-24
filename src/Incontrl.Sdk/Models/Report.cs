using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Represents a report for a subscription.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The subscription id.
        /// </summary>
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// The period the the report covers.
        /// </summary>
        public Period Period { get; set; }

        /// <summary>
        /// An overall report for all document types.
        /// </summary>
        public ReportInfo Overall { get; set; }

        /// <summary>
        /// A report for every document type.
        /// </summary>
        public ReportInfo[] PerType { get; set; }
    }

    /// <summary>
    /// Contains that data of a report.
    /// </summary>
    public class ReportInfo
    {
        /// <summary>
        /// Basic info for the document type.
        /// </summary>
        public DocumentTypeBase Type { get; set; }

        /// <summary>
        /// The total number of documents.
        /// </summary>
        public int TotalDocuments { get; set; }

        /// <summary>
        /// The total sales tax.
        /// </summary>
        public decimal? TotalSalesTax { get; set; }

        /// <summary>
        /// The total of other taxes (excluding sales tax).
        /// </summary>
        public decimal? TotalOtherTax { get; set; }

        /// <summary>
        /// The overall tax.
        /// </summary>
        public decimal? TotalTax { get; set; }
    }
}
