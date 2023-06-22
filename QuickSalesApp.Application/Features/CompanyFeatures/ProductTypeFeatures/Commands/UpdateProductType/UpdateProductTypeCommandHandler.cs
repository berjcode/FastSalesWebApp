using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.UpdateProductType;

public sealed class UpdateProductTypeCommandHandler : ICommandHandler<UpdateProductTypeCommand, UpdateProductTypeCommandResponse>
{
    private readonly IProductTypeService _productTypeService;

    public UpdateProductTypeCommandHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<UpdateProductTypeCommandResponse> Handle(UpdateProductTypeCommand request, CancellationToken cancellationToken)
    {
        ProductType type = await _productTypeService.GetByIdAsync(request.Id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        ProductType type2 = await _productTypeService.GetByNameAsync(request.Name, request.CompanyId);
        if (type2 != null && type2.IsActive == true && type2.Id != request.Id && type2.Name == request.Name) throw new Exception("Değiştirmek Istediğiniz Stok Türü Zaten Ekli");

        await _productTypeService.UpdateAsync(request);
        return new();
    }
}
