using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetAllTransactionType;

public sealed record GetAllTransactionTypeQuery(
        string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllTransactionTypeQueryResponse>>;