using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;

public sealed record GetByIdProductTransactionQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetByIdProductTransactionQueryResponse>;