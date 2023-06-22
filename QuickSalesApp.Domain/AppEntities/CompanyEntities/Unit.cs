

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class Unit : EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Factor { get; set; }
    public bool IsDat { get; set; }
    public virtual ICollection<ProductUnit> ProductUnits { get; set; }
}
