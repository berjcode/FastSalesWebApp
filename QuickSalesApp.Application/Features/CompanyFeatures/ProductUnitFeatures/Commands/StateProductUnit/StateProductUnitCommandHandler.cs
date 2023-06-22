using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.StateProductUnit;

public sealed class StateProductUnitCommandHandler : ICommandHandler<StateProductUnitCommand,StateProductUnitCommandResponse>
{
    private readonly IProductUnitService _productUnitService;

    public StateProductUnitCommandHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<StateProductUnitCommandResponse> Handle(StateProductUnitCommand request, CancellationToken cancellationToken)
    {
        ProductUnit productUnit = await _productUnitService.GetByIdAsync(request.Id, request.CompanyId);
        if (productUnit == null) throw new Exception(ExceptionMessage.NullDataException);

        productUnit.DeleterName = request.DeleterName;
        productUnit.IsDefault = request.IsDefault;
        productUnit.DeletedTime = DateTime.Now;

        await _productUnitService.ChangeState(productUnit, request.CompanyId);
        return new();
    }
}
