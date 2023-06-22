using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetAllCurrency;

public sealed record GetAllCurrencyQueryResponse(

       int Id,
  string Name,
    string CreatorName,
     DateTime? CreatedDate,
     string UpdaterName,
    DateTime? UpdateDate,
    bool? IsActive
  );


