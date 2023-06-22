using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllFilterVatType;

public sealed record GetAllFilterVatTypeQuery(
        string CompanyId,
        string Expression,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllFilterVatTypeQueryResponse>>;