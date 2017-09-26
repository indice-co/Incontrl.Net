namespace Incontrl.Net.Models
{
    public enum StatusOfInvoice : short
    {
        Draft = 0,
        Issued = 1,
        Overdue = 2,
        Partial = 3,
        Paid = 4,
        Void = 5,
        Deleted = 6
    }
}
