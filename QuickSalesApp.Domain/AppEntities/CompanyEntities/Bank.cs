
using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public  class Bank :EntityBase
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string BranchNumber { get; set; }
    public string BranchName { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public  ICollection<BankBankAccount> BankBankAccounts { get; set; }
    public  string CompanyId { get; set; }
}
