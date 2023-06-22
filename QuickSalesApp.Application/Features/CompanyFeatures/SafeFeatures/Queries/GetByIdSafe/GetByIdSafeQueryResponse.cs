namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetByIdSafe;

public sealed record GetByIdSafeQueryResponse(
        int Id,
        string Code,
        string Name,
        string CurrencyName,
        decimal? Credit,
        decimal? Debt,
        decimal? Remainder,
        string CompanyId,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );