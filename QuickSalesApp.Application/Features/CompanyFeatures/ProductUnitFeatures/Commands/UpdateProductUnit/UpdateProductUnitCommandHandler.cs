using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.UpdateProductUnit;

public sealed class UpdateProductUnitCommandHandler: ICommandHandler<UpdateProductUnitCommand, UpdateProductUnitCommandResponse>
{
    private readonly IProductUnitService _productUnitService;

    public UpdateProductUnitCommandHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<UpdateProductUnitCommandResponse> Handle(UpdateProductUnitCommand request, CancellationToken cancellationToken)
    {
        ProductUnit productUnit = await _productUnitService.GetByIdAsync(request.Id, request.CompanyId);
        if (productUnit == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        await _productUnitService.UpdateAsync(request);
        return new UpdateProductUnitCommandResponse();
    }
}
