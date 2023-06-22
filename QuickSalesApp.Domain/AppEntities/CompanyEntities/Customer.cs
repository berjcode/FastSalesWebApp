

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class Customer:EntityBase
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string GroupCode { get; set; }

    public int CustomerTypeId { get; set; }

    public virtual CustomerType CustomerType { get; set; }

    public string Address { get; set; }

    public string Address2 { get; set; }

    
    public string CellPhone1 { get; set; }

   
    public string CellPhone2 { get; set; }

   
    public string Telephone { get; set; }

    public string Email { get; set; }

    public string TaxOffice { get; set; }

    
    public string TaxNumber { get; set; }

    public int SPECode1 { get; set; }

    public int SPECode2 { get; set; }

    public int SPECode3 { get; set; }

    public int SPECode4 { get; set; }

    public int SPECode5 { get; set; }

    public bool IsView { get; set; }
    public string City { get; set; }
    public string Town { get; set; }
    public string CompanyId { get; set; }
}
