namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetAllSafeTransaction;

public sealed record GetAllSafeTransactionQueryResponse(
        int Id,
        string PlugNo,
        string SafeCode,
        DateTime? TransactionDate,
        string Text,
        decimal Debt,
        decimal Credit,
        decimal Remainder,
        string ProcessTypeName,
        string CompanyId
    );