using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetAllBankTransaction;

public sealed  record GetAllBankTransactionQuery(
    string CompanyId,
        int PageNumber,
        int PageSize
    ):IQuery<PaginationResult<GetAllBankTransactionQueryResponse>>;
