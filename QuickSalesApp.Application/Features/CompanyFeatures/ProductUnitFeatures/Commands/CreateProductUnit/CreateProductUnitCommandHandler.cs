using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.CreateProductUnit;

public sealed class CreateProductUnitCommandHandler : ICommandHandler<CreateProductUnitCommand, CreateProductUnitCommandResponse>
{
    private IProductUnitService _productUnitService;

    public CreateProductUnitCommandHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<CreateProductUnitCommandResponse> Handle(CreateProductUnitCommand request, CancellationToken cancellationToken)
    {
        await _productUnitService.CreateAsync(request, cancellationToken);
        return new();
    }
}
