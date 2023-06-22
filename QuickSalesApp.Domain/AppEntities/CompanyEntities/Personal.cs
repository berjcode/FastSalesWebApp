

using QuickSalesApp.Domain.Abstractions;

namespace QuickSalesApp.Domain.AppEntities.CompanyEntities;

public class Personal:EntityBase
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Adress1 { get; set; }
    public string Adress2 { get; set; }
    public string CellPhone1 { get; set; }
    public string CellPhone2 { get; set; }
    //is required (true yapılacak)
    public string Telephone { get; set; }
    public string Email { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int DepartmentId { get; set; }
    public bool IsView { get; set; }
    public  Department Department { get; set; }
    public string CompanyId { get; set; }
}
