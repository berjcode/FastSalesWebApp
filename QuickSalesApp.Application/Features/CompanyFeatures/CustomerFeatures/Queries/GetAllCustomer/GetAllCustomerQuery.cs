

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;

public sealed record GetAllCustomerQuery (
    string CompanyId,
    int PageNumber,
    int PageSize 

    ) : IQuery<PaginationResult<GetAllCustomerQueryResponse>>;

