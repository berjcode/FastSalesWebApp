using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetAllTransactionType;

public sealed record GetAllTransactionTypeQueryResponse(
        int Id,
        string Name,
        int Order
    ) : IQuery<GetAllTransactionTypeQueryResponse>;