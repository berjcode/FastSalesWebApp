using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByIdProduct;

public sealed record GetByIdProductQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetByIdProductQueryResponse>;
