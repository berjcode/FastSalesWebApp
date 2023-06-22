namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;

public sealed record GetSafeTransactionQueryResponse(
        int Id,
        string PlugNo,
        string SafeCode,
        DateTime? TransactionDate,
        string Text,
        decimal Debt,
        decimal Credit,
        decimal Remainder,
        string TransactionTypesName,
        string CompanyId,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );