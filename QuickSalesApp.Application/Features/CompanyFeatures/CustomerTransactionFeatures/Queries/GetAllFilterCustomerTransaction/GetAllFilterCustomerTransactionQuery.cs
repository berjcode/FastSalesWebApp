using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetAllFilterCustomerTransaction;

public sealed record GetAllFilterCustomerTransactionQuery(
     string CompanyId,
    int PageNumber,
    int PageSize,
    string Expression,
    string search
    ) :IQuery<PaginationResult<GetAllFilterCustomerTransactionQueryResponse>>;

