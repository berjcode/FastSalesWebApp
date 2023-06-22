using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllActiveVatType;

public sealed record GetAllActiveVatTypeQuery(
    string CompanyId,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllActiveVatTypeQueryResponse>>;