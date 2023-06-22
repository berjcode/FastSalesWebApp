using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory;

public sealed record GetAllCategoryQueryResponse(
    int Id,
  string Name,
  string Description,
  string CreatorName,
  DateTime? CreatedDate,
   string UpdaterName,
  DateTime? UpdateDate,
  bool? IsActive,
  List<ProductDto> Products);





