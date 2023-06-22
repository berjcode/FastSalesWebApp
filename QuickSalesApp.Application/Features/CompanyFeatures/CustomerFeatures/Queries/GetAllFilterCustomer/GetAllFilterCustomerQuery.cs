

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;

public sealed record GetAllFilterCustomerQuery (
    string CompanyId,
    string Expression,
    string search,
    int PageNumber,
    int PageSize

    ) : IQuery<PaginationResult<GetAllFilterCustomerQueryResponse>>;

