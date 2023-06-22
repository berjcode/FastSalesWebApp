using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllByFilterProductUnit;

public sealed record GetAllByFilterProductUnitQuery(
        string CompanyId,
        string Expression,
        string search,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllByFilterProductUnitQueryResponse>>;