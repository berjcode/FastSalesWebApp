

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllCustomerType;

public sealed record GetAllCustomerTypeQuery (
    string CompanyId,
    int PageNumber,
    int PageSize 

    ) : IQuery<PaginationResult<GetAllCustomerTypeQueryResponse>>;

