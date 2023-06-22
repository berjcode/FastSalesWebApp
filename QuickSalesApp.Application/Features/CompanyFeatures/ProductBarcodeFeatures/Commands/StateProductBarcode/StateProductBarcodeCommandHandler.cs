using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.StateProductBarcode;

public sealed class StateProductBarcodeCommandHandler : ICommandHandler<StateProductBarcodeCommand, StateProductBarcodeCommandResponse>
{
    private readonly IProductBarcodeService _productBarcodeService;

    public StateProductBarcodeCommandHandler(IProductBarcodeService productBarcodeService)
    {
        _productBarcodeService = productBarcodeService;
    }

    public async Task<StateProductBarcodeCommandResponse> Handle(StateProductBarcodeCommand request, CancellationToken cancellationToken)
    {
        ProductBarcode barcode = await _productBarcodeService.GetByIdAsync(request.Id,request.CompanyId);
        if (barcode == null) throw new Exception(ExceptionMessage.NullDataException);

        barcode.IsActive = request.IsActive;
        barcode.DeleterName = request.DeleterName;
        barcode.DeletedTime = DateTime.Now;
        await _productBarcodeService.ChangeState(barcode,request.CompanyId);
        return new();
    }
}
