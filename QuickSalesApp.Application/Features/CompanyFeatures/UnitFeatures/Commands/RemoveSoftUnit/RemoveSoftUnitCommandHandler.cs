using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveSoftUnit;

public sealed class RemoveSoftUnitCommandHandler : ICommandHandler<RemoveSoftUnitCommand, RemoveSoftUnitCommandResponse>
{
    private readonly IUnitService _unitService;

    public RemoveSoftUnitCommandHandler(IUnitService unitService)
    {
        _unitService = unitService;
    }

    public async Task<RemoveSoftUnitCommandResponse> Handle(RemoveSoftUnitCommand request, CancellationToken cancellationToken)
    {
        Unit unit = await _unitService.GetByIdAsync(request.UnitId, request.CompanyId);
        if (unit == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        var check = await _unitService.GetByIdForCheck(request.CompanyId, request.UnitId);
        if (check.ProductName != null) throw new Exception(ExceptionMessage.UnitNotDeleteException);

        unit.IsDelete = request.IsDelete;
        unit.DeleterName = request.DeleterName;
        unit.DeletedTime = DateTime.Now;
        unit.IsActive = false;

        await _unitService.RemoveByIdSoft(request.CompanyId, unit);
        return new();
    }
}
