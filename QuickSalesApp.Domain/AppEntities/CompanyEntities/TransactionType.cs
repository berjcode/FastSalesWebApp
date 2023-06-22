using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class TransactionType :EntityBase
{
    public int Id { get; set; }

    public string Name { get; set; }
    public int Order { get; set; }
    public string CompanyId { get; set; }
    public  ICollection<BankTransaction> BankTransactions { get; set; }
    public  ICollection<ProductTransaction> ProductTransactions { get; set; }
    public  ICollection<SafeTransaction> SafeTransactions { get; set; }
    public  ICollection<CustomerTransaction> CustomerTransactions { get; set; }

}
