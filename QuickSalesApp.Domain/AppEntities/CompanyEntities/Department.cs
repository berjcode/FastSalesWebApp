

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class Department:EntityBase
{
    public string Name { get; set; }

    public ICollection<Personal> Personals { get; set; }
}
