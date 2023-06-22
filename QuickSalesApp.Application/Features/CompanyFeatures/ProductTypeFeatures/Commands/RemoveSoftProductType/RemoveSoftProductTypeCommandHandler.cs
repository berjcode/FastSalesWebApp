using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveSoftProductType;

public sealed class RemoveSoftProductTypeCommandHandler : ICommandHandler<RemoveSoftProductTypeCommand, RemoveSoftProductTypeCommandResponse>
{
    private readonly IProductTypeService _productTypeService;

    public RemoveSoftProductTypeCommandHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<RemoveSoftProductTypeCommandResponse> Handle(RemoveSoftProductTypeCommand request, CancellationToken cancellationToken)
    {
        ProductType type = await _productTypeService.GetByIdAsync(request.id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);
       
        var check = await _productTypeService.GetByIdForCheck(request.CompanyId, request.id);
        if (check.ProductName != null) throw new Exception(ExceptionMessage.ProductTypeNotDeleteException);

        type.IsDelete = request.IsDelete;
        type.DeleterName = request.DeleterName;
        type.DeletedTime = DateTime.Now;
        type.IsActive = false;

        await _productTypeService.RemoveByIdSoft(request.CompanyId, type);
        return new();
    }
}
