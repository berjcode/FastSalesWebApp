using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetProductLastCode;

public sealed class GetProductLastCodeQueryHandler : IQueryHandler<GetProductLastCodeQuery, GetProductLastCodeQueryResponse>
{
    private readonly IProductService _productService;

    public GetProductLastCodeQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<GetProductLastCodeQueryResponse> Handle(GetProductLastCodeQuery request, CancellationToken cancellationToken)
    {
        var result = _productService.GetLastCode(request);
        return new(result);
    }
}
