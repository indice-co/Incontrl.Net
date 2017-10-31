using System;

namespace Incontrl.Sdk.Models
{
    public class TransactionFilter : RangeFilter
    {
        public Guid? BatchId { get; set; }
    }
}
