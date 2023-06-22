
using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class Currency :EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Safe> Safes { get; set; }
    public virtual ICollection<BankAccount> BankAcounts { get; set; }
}
