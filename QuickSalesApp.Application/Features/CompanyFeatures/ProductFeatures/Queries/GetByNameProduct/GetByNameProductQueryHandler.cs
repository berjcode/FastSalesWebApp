using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByNameProduct;

public sealed class GetByNameProductQueryHandler : IQueryHandler<GetByNameProductQuery, GetByNameProductQueryResponse>
{
    private readonly IProductService _productService;

    public GetByNameProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<GetByNameProductQueryResponse> Handle(GetByNameProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetByNameAsync(request.Name, request.CompanyId);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return new(result);
    }
}
