using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory;

public sealed record GetAllCategoryQuery(
    string CompanyId,
    int PageNumber,
    int PageSize
    ) : IQuery<PaginationResult<GetAllCategoryQueryResponse>>;

