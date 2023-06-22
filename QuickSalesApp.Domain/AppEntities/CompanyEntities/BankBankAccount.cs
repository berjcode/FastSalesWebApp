
using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class BankBankAccount : EntityBase
{
    public int BankId { get; set; }
    public int AccountId { get; set; }
    public  Bank Bank { get; set; }
    public BankAccount BankAccount { get; set; }
    public string CompanyId { get; set; }
}
