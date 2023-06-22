using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;

public sealed record GetAllFilterUnitQuery(
        string CompanyId,
        string Expression,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllFilterUnitQueryResponse>>;