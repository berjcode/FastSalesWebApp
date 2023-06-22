using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveSoftProductUnit;

public sealed class RemoveSoftProductUnitCommandHandler : ICommandHandler<RemoveSoftProductUnitCommand, RemoveSoftProductUnitCommandResponse>
{
    private readonly IProductUnitService _productUnitService;

    public RemoveSoftProductUnitCommandHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<RemoveSoftProductUnitCommandResponse> Handle(RemoveSoftProductUnitCommand request, CancellationToken cancellationToken)
    {
        ProductUnit productUnit = await _productUnitService.GetByIdAsync(request.Id, request.CompanyId);
        if (productUnit == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _productUnitService.RemoveByIdSoft(request.CompanyId,request.Id);
        return new();
    }
}
