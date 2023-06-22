using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllByFilterProduct;

public sealed record GetAllByFilterProductQuery(
        string CompanyId,
        string Expression,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllByFilterProductQueryResponse>>;