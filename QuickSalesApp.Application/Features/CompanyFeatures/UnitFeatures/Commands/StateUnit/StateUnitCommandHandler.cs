using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.StateUnit;

public sealed class StateUnitCommandHandler : ICommandHandler<StateUnitCommand, StateUnitCommandResponse>
{
    private readonly IUnitService _unitService;

    public StateUnitCommandHandler(IUnitService unitService)
    {
        _unitService = unitService;
    }

    public async Task<StateUnitCommandResponse> Handle(StateUnitCommand request, CancellationToken cancellationToken)
    {
        Unit unit = await _unitService.GetByIdAsync(request.Id, request.CompanyId);
        if (unit == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        unit.IsActive = request.IsActive;
        unit.DeleterName = request.DeleterName;
        unit.DeletedTime = DateTime.Now;

        await _unitService.ChangeState(unit, request.CompanyId);
        return new();
    }
}
