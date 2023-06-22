using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveUnit;

public sealed class RemoveUnitCommandHandler : ICommandHandler<RemoveUnitCommand, RemoveUnitCommandResponse>
{
    private readonly IUnitService _unitService;

    public RemoveUnitCommandHandler(IUnitService unitService)
    {
        _unitService = unitService;
    }

    public async Task<RemoveUnitCommandResponse> Handle(RemoveUnitCommand request, CancellationToken cancellationToken)
    {
        Unit unit = await _unitService.GetByIdAsync(request.id, request.CompanyId);
        if (unit == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _unitService.RemoveByIdHard(request);
        return new();
    }
}
