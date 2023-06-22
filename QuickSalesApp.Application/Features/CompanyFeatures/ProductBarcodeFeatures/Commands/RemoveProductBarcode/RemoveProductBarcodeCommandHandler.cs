using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveProductBarcode;

public sealed class RemoveProductBarcodeCommandHandler : ICommandHandler<RemoveProductBarcodeCommand, RemoveProductBarcodeCommandResponse>
{
    private readonly IProductBarcodeService _productBarcodeService;

    public RemoveProductBarcodeCommandHandler(IProductBarcodeService productBarcodeService)
    {
        _productBarcodeService = productBarcodeService;
    }

    public async Task<RemoveProductBarcodeCommandResponse> Handle(RemoveProductBarcodeCommand request, CancellationToken cancellationToken)
    {
        ProductBarcode barcode = await _productBarcodeService.GetByIdAsync(request.Id, request.CompanyId);
        if (barcode == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _productBarcodeService.RemoveByIdHard(request);
        return new();
    }
}
