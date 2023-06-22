using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class ProductUnit:EntityBase
{
    public int ProductId { get; set; }
 
    public decimal Factor { get; set; }
    public bool IsDefault { get; set; }
    public decimal Price { get; set; }

    public decimal Amount { get; set; }
    public decimal Weight { get; set; }
    public int UnitId { get; set; }

    public bool IsVat { get; set; }
    public Unit Unit { get; set; }

    public Product Product { get; set; }
  
    public ProductBarcode ProductBarcode { get; set; }

}
