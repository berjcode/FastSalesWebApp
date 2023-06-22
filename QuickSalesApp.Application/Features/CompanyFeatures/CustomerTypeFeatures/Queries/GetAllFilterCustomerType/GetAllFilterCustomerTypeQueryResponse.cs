using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllFilterCustomerType;

public sealed record GetAllFilterCustomerTypeQueryResponse (

      int Id,
      string Name,
       bool? IsActive,    
       string CreatorName,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate





    );

