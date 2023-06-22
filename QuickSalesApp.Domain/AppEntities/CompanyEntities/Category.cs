using QuickSalesApp.Domain.Abstractions;
namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;
public class Category : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set;}


}
