using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllCustomerType;

public sealed record GetAllCustomerTypeQueryResponse (int Id,
  string Name,
  
  string CreatorName,
  DateTime? CreatedDate,
   string UpdaterName,
  DateTime? UpdateDate,
  bool? IsActive


    );
