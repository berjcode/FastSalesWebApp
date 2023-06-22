using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllForProductList;

public sealed record GetAllForProductListQuery(
        string CompanyId,
        string Expression,
        string search,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllForProductListQueryResponse>>;