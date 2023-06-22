using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveProductType;

public sealed class RemoveProductTypeCommandHandler : ICommandHandler<RemoveProductTypeCommand, RemoveProductTypeCommandResponse>
{
    private readonly IProductTypeService _productTypeService;

    public RemoveProductTypeCommandHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<RemoveProductTypeCommandResponse> Handle(RemoveProductTypeCommand request, CancellationToken cancellationToken)
    {
        ProductType type = await _productTypeService.GetByIdAsync(request.id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _productTypeService.RemoveByIdHard(request);
        return new();
    }
}
