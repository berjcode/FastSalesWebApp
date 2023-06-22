using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetWithUnactive;

public sealed record GetWithUnactiveQuery(
      string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetWithUnactiveResponse>>;