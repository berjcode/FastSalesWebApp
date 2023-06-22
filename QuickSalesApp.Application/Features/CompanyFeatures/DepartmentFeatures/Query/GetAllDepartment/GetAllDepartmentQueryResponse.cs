using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;

public sealed record GetAllDepartmentQueryResponse (int Id,
  string Name,
  
  string CreatorName,
  DateTime? CreatedDate,
   string UpdaterName,
  DateTime? UpdateDate,
  bool? IsActive


    );
