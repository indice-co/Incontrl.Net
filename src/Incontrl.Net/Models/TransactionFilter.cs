using System;

namespace Incontrl.Net.Models
{
    public class TransactionFilter : RangeFilter
    {
        public Guid? BatchId { get; set; }
    }
}
