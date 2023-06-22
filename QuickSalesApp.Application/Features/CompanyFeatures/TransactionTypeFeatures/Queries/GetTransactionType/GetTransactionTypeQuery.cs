using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetTransactionType;

public sealed record GetTransactionTypeQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetTransactionTypeQueryResponse>;
