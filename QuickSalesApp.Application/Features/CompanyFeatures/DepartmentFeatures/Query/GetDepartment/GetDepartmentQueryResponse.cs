

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;

public sealed record GetDepartmentQueryResponse(
    int Id,
    string Name, 
    string CreatorName,
    DateTime? CreatedDate,
      string UpdaterName,
  DateTime? UpdateDate,
     bool? IsActive
    );
