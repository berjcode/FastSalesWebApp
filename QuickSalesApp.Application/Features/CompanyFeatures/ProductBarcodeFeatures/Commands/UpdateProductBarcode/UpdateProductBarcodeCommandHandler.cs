using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.UpdateProductBarcode;

public sealed class UpdateProductBarcodeCommandHandler : ICommandHandler<UpdateProductBarcodeCommand, UpdateProductBarcodeCommandResponse>
{
    private readonly IProductBarcodeService _productBarcodeService;

    public UpdateProductBarcodeCommandHandler(IProductBarcodeService productBarcodeService)
    {
        _productBarcodeService = productBarcodeService;
    }

    public async Task<UpdateProductBarcodeCommandResponse> Handle(UpdateProductBarcodeCommand request, CancellationToken cancellationToken)
    {
        ProductBarcode barcode = await _productBarcodeService.GetByIdAsync(request.Id, request.CompanyId);
        if (barcode == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        ProductBarcode barcode2 = await _productBarcodeService.GetByCodeAsync(request.Barcode, request.CompanyId);
        if (barcode2 != null && barcode2.IsActive == true && barcode2.Id != request.Id && barcode2.Barcode == request.Barcode) throw new Exception("Değiştirmek İstediğiniz Barkod Zaten Kullanımda");

        await _productBarcodeService.UpdateAsync(request);
        return new();
    }
}
