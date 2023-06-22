using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.CreateProductBarcode;

public sealed class CreateProductBarcodeCommandHandler : ICommandHandler<CreateProductBarcodeCommand, CreateProductBarcodeCommandResponse>
{
    private readonly IProductBarcodeService _service;

    public CreateProductBarcodeCommandHandler(IProductBarcodeService service)
    {
        _service = service;
    }

    public async Task<CreateProductBarcodeCommandResponse> Handle(CreateProductBarcodeCommand request, CancellationToken cancellationToken)
    {
        ProductBarcode barcode = await _service.GetByCodeAsync(request.Barcode, request.CompanyId);
        if (barcode != null) throw new Exception("Eklemek Istediğiniz Barkod Zaten Ekli");

        await _service.CreateAsync(request,cancellationToken);
        return new();
    }
}
