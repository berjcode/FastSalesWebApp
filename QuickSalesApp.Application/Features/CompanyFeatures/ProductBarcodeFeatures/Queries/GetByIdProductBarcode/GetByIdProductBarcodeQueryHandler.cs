using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetByIdProductBarcode;

public sealed class GetByIdProductBarcodeQueryhandler : IQueryHandler<GetByIdProductBarcodeQuery, GetByIdProductBarcodeQueryResponse>
{
    private readonly IProductBarcodeService _productBarcodeService;

    public GetByIdProductBarcodeQueryhandler(IProductBarcodeService productBarcodeService)
    {
        _productBarcodeService = productBarcodeService;
    }

    public async Task<GetByIdProductBarcodeQueryResponse> Handle(GetByIdProductBarcodeQuery request, CancellationToken cancellationToken)
    {
        var result = await _productBarcodeService.GetProductBarcode(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
