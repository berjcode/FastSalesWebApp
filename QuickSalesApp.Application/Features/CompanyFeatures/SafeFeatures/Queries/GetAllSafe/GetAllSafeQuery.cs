using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetAllSafe;

public sealed record GetAllSafeQuery(
        string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllSafeQueryResponse>>;