using System;

namespace Incontrl.Sdk.Models
{
    public class BankAccount
    {
        public Guid? Id { get; set; }

        public string Code { get; set; }
        public string Bank { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }

        //baseline balance
        public Balance Baseline { get; set; }
        public TransactionProviderConfig Provider { get; set; }
        public ReconciliationConfig Reconciliation { get; set; }
    }
}
