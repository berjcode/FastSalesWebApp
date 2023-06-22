using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetByIdSafe;

public sealed record GetByIdSafeQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetByIdSafeQueryResponse>;
