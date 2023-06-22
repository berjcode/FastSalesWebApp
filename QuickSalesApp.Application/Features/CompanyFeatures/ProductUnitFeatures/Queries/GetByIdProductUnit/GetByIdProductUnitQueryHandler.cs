using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;

public sealed class GetByIdProductUnitQueryHandler : IQueryHandler<GetByIdProductUnitQuery,GetByIdProductUnitQueryResponse>
{
    private readonly IProductUnitService _productUnitService;

    public GetByIdProductUnitQueryHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<GetByIdProductUnitQueryResponse> Handle(GetByIdProductUnitQuery request, CancellationToken cancellationToken)
    {
        var result = await _productUnitService.GetProductUnit(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
