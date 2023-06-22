

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class VatType:EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public  ICollection<Product>  Products{ get; set; }
}
