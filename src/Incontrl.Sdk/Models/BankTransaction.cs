using System;

namespace Incontrl.Sdk.Models
{
    public class BankTransaction
    {
        public Guid? Id { get; set; }
        public byte[] Hash { get; set; }
        public BankTransactionType? Type { get; set; }
        public DateTime? Date { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
        public decimal Amount { get; set; }
    }
}
