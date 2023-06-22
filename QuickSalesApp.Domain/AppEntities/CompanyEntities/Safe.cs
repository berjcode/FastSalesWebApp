

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class Safe :EntityBase
{
    public string Code { get; set; }
    public string Name { get; set; }
    public int CurrencyType { get; set; }
    public virtual Currency Currency { get; set; }
    public decimal? Credit { get; set; } = 0;
    public decimal? Debt { get; set; } = 0;
    public decimal? Remainder { get; set; } = 0;

    public string CompanyId { get; set; }
}
