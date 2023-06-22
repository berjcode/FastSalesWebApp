using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.UpdateUnit;

public sealed class UpdateUnitCommandHandler : ICommandHandler<UpdateUnitCommand, UpdateUnitCommandResponse>
{
    private readonly IUnitService _unitService;

    public UpdateUnitCommandHandler(IUnitService unitService)
    {
        _unitService = unitService;
    }

    public async Task<UpdateUnitCommandResponse> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
    {
        Unit unit = await _unitService.GetByIdAsync(request.Id, request.CompanyId);
        if (unit == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        Unit unit2 = await _unitService.GetByNameAsync(request.Name, request.CompanyId);
        if (unit2 != null && unit2.IsActive == true && unit2.Id != request.Id && unit2.Name == request.Name) throw new Exception("Değiştirmek İstediğiniz KDV Adı Zaten Kullanımda");

        await _unitService.UpdateAsync(request);
        return new();
    }
}
