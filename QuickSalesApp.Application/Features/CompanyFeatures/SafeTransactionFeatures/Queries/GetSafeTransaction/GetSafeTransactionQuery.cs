using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;

public sealed record GetSafeTransactionQuery(
         int Id,
         string CompanyId
    ) : IQuery<GetSafeTransactionQueryResponse>;