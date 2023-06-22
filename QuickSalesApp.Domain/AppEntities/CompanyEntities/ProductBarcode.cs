using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class ProductBarcode :EntityBase
{
    public int ProductUnitId { get; set; }
    public string Barcode { get; set; }

    public ProductUnit ProductUnit { get; set; }
}
