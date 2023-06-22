

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class ProductType :EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Product { get; set; }
}
