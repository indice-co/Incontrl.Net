using System;
using System.Collections.Generic;

namespace Incontrl.Sdk.Models
{
    public class BulkLoadTransactionsRequest
    {
        public Guid? BatchId { get; set; }
        public List<Transaction> Data { get; set; }
    }
}
