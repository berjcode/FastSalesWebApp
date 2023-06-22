using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetAllProductTransaction;

public sealed record GetAllProductTransactionQuery(
        string CompanyId,
        int PageNumber,
        int PageSize,
        string Expression,
        string search
    ) : IQuery<PaginationResult<GetAllProductTransactionQueryResponse>>;