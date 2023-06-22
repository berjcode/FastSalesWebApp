using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetAllSafeTransaction;

public sealed record GetAllSafeTransactionQuery(
        string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllSafeTransactionQueryResponse>>;