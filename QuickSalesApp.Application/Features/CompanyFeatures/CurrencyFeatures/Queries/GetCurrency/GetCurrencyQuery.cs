using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetCurrency;

public sealed  record GetCurrencyQuery(
    string CompanyId,
    int id): IQuery<GetCurrencyQueryResponse>;

