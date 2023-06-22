using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByIdProduct;

public sealed class GetByIdProductQueryHandler : IQueryHandler<GetByIdProductQuery, GetByIdProductQueryResponse>
{
    private readonly IProductService _productService;

    public GetByIdProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _productService.GetProduct(request.CompanyId,request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
