using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.CreateUnit;

public sealed class CreateUnitCommandHandler : ICommandHandler<CreateUnitCommand, CreateUnitCommandResponse>
{
    private readonly IUnitService _unitService;

    public CreateUnitCommandHandler(IUnitService unitService)
    {
        _unitService = unitService;
    }

    public async Task<CreateUnitCommandResponse> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
    {
        Unit unit = await _unitService.GetByNameAsync(request.Name, request.CompanyId);
        if (unit != null) throw new Exception("Eklemek Istediğiniz Birim Zaten Ekli.");

        await _unitService.CreateAsync(request,cancellationToken);
        return new();
    }
}
