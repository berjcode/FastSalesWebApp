

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class BankAccount :EntityBase
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string IBAN { get; set; }
    public string AcountNumber { get; set; }
    public int CurrencyId { get; set; }
    public  Currency Currency { get; set; }
    public  ICollection<BankBankAccount> BankBankAccounts { get; set; }

    public string CompanyId { get; set; }
}
