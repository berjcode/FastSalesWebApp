using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;

public sealed class GetAllBasketProductbyBarcodeQueryHandler : IQueryHandler<GetAllBasketProductbyBarcodeQuery, GetAllBasketProductbyBarcodeQueryResponse>
{
    private readonly IProductBarcodeService _productBarcodeService;

    public GetAllBasketProductbyBarcodeQueryHandler(IProductBarcodeService productBarcodeService)
    {
        _productBarcodeService = productBarcodeService;
    }

    public async Task<GetAllBasketProductbyBarcodeQueryResponse> Handle(GetAllBasketProductbyBarcodeQuery request, CancellationToken cancellationToken)
    {

      var  result = await _productBarcodeService.GetAllBasketProductByBarcode(request.CompanyId,request.Barcode);

        if (result == null || result == null) throw new Exception(ExceptionMessage.NullDataException);

      

        return result;

    }
}