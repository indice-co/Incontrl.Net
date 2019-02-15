using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// Represents a report for a subscription.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// The year in which the report applies to.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// An integer value that indicates the order of the report according to it's <see cref="ReportingFrequency"/>.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// The type of this report.
        /// </summary>
        public ReportingFrequency Frequency { get; set; }

        /// <summary>
        /// The total sales tax for all record types.
        /// </summary>
        public decimal? TotalSalesTax { get; set; }

        /// <summary>
        /// The total other tax for all record types.
        /// </summary>
        public decimal? TotalOtherTax { get; set; }

        /// <summary>
        /// The total tax for all record types.
        /// </summary>
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// An overall report for all document types.
        /// </summary>
        public ReportDetails Overall { get; set; }

        /// <summary>
        /// A report for every record type.
        /// </summary>
        public ReportDetails[] PerRecordType { get; set; }

        /// <summary>
        /// The <see cref="DateTime"/> where the report was created.
        /// </summary>
        public DateTimeOffset? CreatedAt { get; set; }
    }

    /// <summary>
    /// Contains that data of a report.
    /// </summary>
    public class ReportDetails
    {
        /// <summary>
        /// Basic info for the document type.
        /// </summary>
        public RecordType? RecordType { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        public decimal? Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalNet { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalDiscount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalPayable { get; set; }
    }

    /// <summary>
    /// An enum that describes the frequency that a report is generated.
    /// </summary>
    public enum ReportingFrequency : short
    {
        /// <summary>
        /// Monthly report.
        /// </summary>
        Monthly = 1,

        /// <summary>
        /// Quarterly report.
        /// </summary>
        Quarterly = 3,

        /// <summary>
        /// Semesterly report.
        /// </summary>
        Semesterly = 6,

        /// <summary>
        /// Yearly report.
        /// </summary>
        Yearly = 12,

        /// <summary>
        /// Biyearly report.
        /// </summary>
        Biyearly = 24
    }

    /// <summary>
    /// The type of the report.
    /// </summary>
    public enum ReportType : short
    {
        /// <summary>
        /// Issued
        /// </summary>
        Issued,

        /// <summary>
        /// Paid
        /// </summary>
        Paid,

        /// <summary>
        /// Due
        /// </summary>
        Due
    }
}
