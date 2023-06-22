using QuickSalesApp.Domain.Abstractions;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Domain.AppEntities;

public sealed  class MainCompany :Entity
{
    public string Name { get; set; }

    public ICollection<Company>  Companies { get; set; }

    
}
