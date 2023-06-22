using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByNameProduct;

public sealed record GetByNameProductQuery(
        string Name,
        string CompanyId
    ) : IQuery<GetByNameProductQueryResponse>;
