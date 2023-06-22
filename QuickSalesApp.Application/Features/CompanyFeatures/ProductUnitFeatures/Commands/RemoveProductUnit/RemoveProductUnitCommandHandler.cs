using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveProductUnit;

public sealed class RemoveProductUnitCommandHandler : ICommandHandler<RemoveProductUnitCommand, RemoveProductUnitCommandResponse>
{
    private readonly IProductUnitService _productUnitService;

    public RemoveProductUnitCommandHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<RemoveProductUnitCommandResponse> Handle(RemoveProductUnitCommand request, CancellationToken cancellationToken)
    {
        ProductUnit productUnit = await _productUnitService.GetByIdAsync(request.Id, request.CompanyId);
        if (productUnit == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _productUnitService.RemoveByIdHard(request);
        return new();
    }
}
