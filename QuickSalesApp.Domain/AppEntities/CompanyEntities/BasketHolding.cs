using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public sealed class BasketHolding:EntityBase
{
   public string ProductName { get; set; }
    public decimal  Price { get; set; }
    public int Amount { get; set; }

    public bool IsStatus { get; set; }

}