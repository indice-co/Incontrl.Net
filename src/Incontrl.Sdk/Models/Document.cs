using System;

namespace Incontrl.Sdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Document
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid? TypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumberPrintable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? DueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DocumentStatus? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? CurrencyRate { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public Recipient Recipient { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PaymentCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DocumentLine[] Lines { get; set; } = new DocumentLine[0];

        /// <summary>
        /// 
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PublicNotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PermaLink { get; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalSalesTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? TotalPayable { get; set; }
    }
}
