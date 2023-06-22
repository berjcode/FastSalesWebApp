using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetUnit;

public sealed record GetUnitQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetUnitQueryResponse>;
