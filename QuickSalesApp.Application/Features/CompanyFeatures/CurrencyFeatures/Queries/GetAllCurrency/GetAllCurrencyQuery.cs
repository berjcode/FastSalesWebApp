using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetAllCurrency;

public sealed record GetAllCurrencyQuery(
    string CompanyId,
    int PageNumber,
    int PageSize
    ) : IQuery<PaginationResult<GetAllCurrencyQueryResponse>>;

