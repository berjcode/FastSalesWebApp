using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllVatType;

public sealed record GetAllVatTypeQuery(
        string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllVatTypeQueryResponse>>;