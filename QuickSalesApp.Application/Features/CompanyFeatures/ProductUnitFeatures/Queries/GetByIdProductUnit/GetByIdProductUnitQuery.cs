using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;

public sealed record GetByIdProductUnitQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetByIdProductUnitQueryResponse>;