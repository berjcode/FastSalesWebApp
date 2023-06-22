

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;


public class ProductTransaction : EntityBase
{


    public string PlugNo { get; set; }
    public string ProductCode { get; set; }

    public DateTime TransactionDate { get; set; }
    public string Text { get; set; }
    public decimal EnteringQuantity { get; set; }
    public decimal OutgoingQuantity { get; set; }
    public decimal Remainder { get; set; }
    public int ProcessTypeId { get; set; }
    public virtual TransactionType TransactionType { get; set; }
    public string CompanyId { get; set; }
    public decimal Amount { get; set; }
    public decimal Weight { get; set; }

}
