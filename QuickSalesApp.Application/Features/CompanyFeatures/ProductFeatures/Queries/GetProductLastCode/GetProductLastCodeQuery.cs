using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetProductLastCode;

public sealed record GetProductLastCodeQuery(
        string CompanyId
    ) : IQuery<GetProductLastCodeQueryResponse>;
