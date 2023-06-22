using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;

public sealed class GetByIdProductTypeQueryHandler : IQueryHandler<GetByIdProductTypeQuery,GetByIdProductTypeQueryResponse>
{
    private readonly IProductTypeService _productTypeService;

    public GetByIdProductTypeQueryHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<GetByIdProductTypeQueryResponse> Handle(GetByIdProductTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await _productTypeService.GetProductType(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
