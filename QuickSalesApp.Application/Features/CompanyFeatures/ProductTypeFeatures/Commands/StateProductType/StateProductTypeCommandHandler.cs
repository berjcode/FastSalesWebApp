using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.StateProductType;

public sealed  class StateProductTypeCommandHandler : ICommandHandler<StateProductTypeCommand, StateProductTypeCommandResponse>
{
    private readonly IProductTypeService _productTypeService;

    public StateProductTypeCommandHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<StateProductTypeCommandResponse> Handle(StateProductTypeCommand request, CancellationToken cancellationToken)
    {
        ProductType type = await _productTypeService.GetByIdAsync(request.Id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.NullDataException);

        type.IsActive = request.IsActive;
        type.DeleterName = request.DeleterName;
        type.DeletedTime = DateTime.Now;

        await _productTypeService.ChangeState(type, request.CompanyId);
        return new();
    }
}
