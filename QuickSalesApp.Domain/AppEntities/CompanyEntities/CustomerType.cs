using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class CustomerType  :EntityBase
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Customer> Customers { get; set; }
}
