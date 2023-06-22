namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetAllProductTransaction;

public sealed record GetAllProductTransactionQueryResponse(
        int Id,
        string PlugNo,
        string ProductCode,
        string Text,
        string TransactionDate,
        decimal EnteringQuantity,
        decimal OutgoingQuantity,
        decimal Remainder,
        bool? IsActive,
        string ProcessTypeName,
        int ProcessTypeId
    );