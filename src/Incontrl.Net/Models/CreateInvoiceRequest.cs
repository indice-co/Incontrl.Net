using System;
using System.Collections.Generic;

namespace Incontrl.Net.Models
{
    public class CreateInvoiceRequest
    {
        public Guid? TypeId { get; set; }
        public int? Number { get; set; }
        public DateTimeOffset? Date { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public InvoiceStatus? Status { get; set; }
        public string CurrencyCode { get; set; }
        public double? CurrencyRate { get; set; }
        public Recipient Recipient { get; set; }
        public string PaymentCode { get; set; }
        public ICollection<InvoiceLine> Lines { get; set; } = new InvoiceLine[0];
        public bool ServerCalculations { get; set; } = true;
        public string Notes { get; set; }
        public string PublicNotes { get; set; }
        public string Tags { get; set; }

        //******************************************************************************
        // Totals (amounts)
        //******************************************************************************
        /// <summary>
        /// Total net amount excluding taxes.
        /// </summary>
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// Total sales tax amount.
        /// </summary>
        public decimal? TotalSalesTax { get; set; }

        /// <summary>
        /// Total tax amount.
        /// </summary>
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// Total amount for invoice (SubTotal + TotalTax).
        /// </summary>
        public decimal? Total { get; set; }

        /// <summary>
        /// Total amount for invoice (SubTotal + TotalTax).
        /// </summary>
        public decimal? TotalPayable { get; set; }
    }
}
