namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetAllSafe;

public sealed record GetAllSafeQueryResponse(
        int Id,
        string Code,
        string Name,
        string CurrencyName,
        decimal? Credit,
        decimal? Debt,
        decimal? Remainder,
        string CompanyId
    );