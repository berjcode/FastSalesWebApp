namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetCurrency;

public sealed record GetCurrencyQueryResponse(int Id,
    string Name,
     string CreatorName,
    DateTime? CreatedDate,
      string UpdaterName,
  DateTime? UpdateDate,
     bool? IsActive



    );


