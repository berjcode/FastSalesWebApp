using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;

public sealed record GetAllUnitQuery(
        string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllUnitQueryResponse>>;