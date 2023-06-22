using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllJustCategory;

public sealed record GetAllJustCategoryQueryResponse(
     int Id,
    string Name,
    int ProductCount)

 ;





