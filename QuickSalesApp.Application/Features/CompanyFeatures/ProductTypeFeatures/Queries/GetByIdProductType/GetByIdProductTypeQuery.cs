using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;

public sealed record GetByIdProductTypeQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetByIdProductTypeQueryResponse>;
