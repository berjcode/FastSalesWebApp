

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public  class CustomerTransaction :EntityBase
{
    public string PlugNo { get; set; }
    public string CustomerCode { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Text { get; set; }
    public string Description { get; set; }
    public decimal Debt { get; set; }
    public decimal Credit { get; set; }
    public decimal Remainder { get; set; }
    public int ProcessTypeId { get; set; }
    public virtual TransactionType TransactionTypes { get; set; }
    public string CompanyId { get; set; }
}
