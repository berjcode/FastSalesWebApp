namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;

public sealed record GetByIdProductTransactionQueryResponse(
    string PlugNo,
    string ProductCode,
    string Text,
    decimal EnteringQuantity,
    decimal OutgoingQuantity,
    decimal Remainder,
    string TransactionTypeName,
    DateTime? CreatedDate,
    string UpdaterName,
    DateTime? UpdateDate,
    bool? IsActive
    );