using System;
using System.Collections.Generic;

namespace Incontrl.Net.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class BulkLoadTransactionsRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid? BatchId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BankTransaction> Data { get; set; }
    }
}
