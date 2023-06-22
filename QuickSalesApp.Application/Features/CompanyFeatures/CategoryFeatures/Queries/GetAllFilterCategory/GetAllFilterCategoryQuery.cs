using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;

public sealed record GetAllFilterCategoryQuery(
        string CompanyId,
        string Expression, 
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllFilterCategoryQueryResponse>>;


// x=> x.IsActive== true