using QuickSalesApp.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class Product : EntityBase
{

    public string Code { get; set; }
    public string Name { get; set; }
    public string GroupCode { get; set; }
    [Column(TypeName = "varchar(MAX)")]
    public string Photo { get; set; }
    public int VatTypeId { get; set; }
    public VatType VatType { get; set; }
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int SPECode1 { get; set; }
    public int SPECode2 { get; set; }
    public int SPECode3 { get; set; }
    public int SPECode4 { get; set; }
    public int SPECode5 { get; set; }

    public ICollection<ProductUnit> ProductUnits { get; set;}

}
