

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllFilterCustomerType;

public sealed record GetAllFilterCustomerTypeQuery(
     string CompanyId,
    string Expression,
    int PageNumber,
    int PageSize


    ) : IQuery<PaginationResult<GetAllFilterCustomerTypeQueryResponse>>;

