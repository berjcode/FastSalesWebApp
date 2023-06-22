using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.StateVatType;

public sealed class StateVatTypeCommandHandler : ICommandHandler<StateVatTypeCommand, StateVatTypeCommandResponse>
{
    private readonly IVatTypeService _vatTypeService;

    public StateVatTypeCommandHandler(IVatTypeService vatTypeService)
    {
        _vatTypeService = vatTypeService;
    }

    public async Task<StateVatTypeCommandResponse> Handle(StateVatTypeCommand request, CancellationToken cancellationToken)
    {
        VatType vatType = await _vatTypeService.GetByIdAsync(request.Id, request.CompanyId);
        if (vatType == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        vatType.IsActive = request.IsActive;
        vatType.DeleterName = request.DeleterName;
        vatType.DeletedTime = DateTime.Now;

        await _vatTypeService.ChangeState(vatType, request.CompanyId);
        return new();
    }
}
