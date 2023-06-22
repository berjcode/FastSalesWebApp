using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetAllBankAccount;

public sealed record GetAllBankAccountQuery(
     string CompanyId,
     int PageNumber,
    int PageSize

    ) : IQuery<PaginationResult<GetAllBankAccountQueryResponse>>;

