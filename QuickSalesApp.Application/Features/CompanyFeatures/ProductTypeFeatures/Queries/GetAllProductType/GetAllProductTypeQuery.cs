using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetAllProductType;

public sealed record GetAllProductTypeQuery(
        string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllProductTypeQueryResponse>>;