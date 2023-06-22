using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetAllBank;

public sealed record GetAllBankQuery(
    string CompanyId,
    int PageNumber,
    int PageSize
    ) : IQuery<PaginationResult<GetAllBankQueryResponse>>;

