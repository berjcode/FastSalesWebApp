using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveSoftProductBarcode;

public sealed class RemoveSoftProductBarcodeCommandHandler : ICommandHandler<RemoveSoftProductBarcodeCommand, RemoveSoftProductBarcodeCommandResponse>
{
    private readonly IProductBarcodeService _service;

    public RemoveSoftProductBarcodeCommandHandler(IProductBarcodeService service)
    {
        _service = service;
    }

    public async Task<RemoveSoftProductBarcodeCommandResponse> Handle(RemoveSoftProductBarcodeCommand request, CancellationToken cancellationToken)
    {
        ProductBarcode barcode = await _service.GetByIdAsync(request.id, request.CompanyId);
        if (barcode == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        barcode.IsDelete = request.IsDelete;
        barcode.DeleterName = request.DeleterName;
        barcode.DeletedTime = DateTime.Now;
        barcode.IsActive = false;
        
        await _service.RemoveByIdSoft(request.CompanyId, barcode);
        return new();
    }
}
