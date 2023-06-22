using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveMainRoleRL;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveByIdMainRoleRL;

public sealed class RemoveByIdMainRoleAndRoleRlCommandHandler : ICommandHandler<RemoveByIdMainRoleAndRoleRlCommand, RemoveByIdMainRoleAndRoleRlCommandResponse>
{

    private readonly IMainRoleAndRoleRelationshipService _mainRoleAndRoleRelationshipService;

    public RemoveByIdMainRoleAndRoleRlCommandHandler(IMainRoleAndRoleRelationshipService mainRoleAndRoleRelationshipService)
    {
        _mainRoleAndRoleRelationshipService = mainRoleAndRoleRelationshipService;
    }

    public async Task<RemoveByIdMainRoleAndRoleRlCommandResponse> Handle(RemoveByIdMainRoleAndRoleRlCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationShip entity = await _mainRoleAndRoleRelationshipService.GetByIdAsync(request.Id);
        if (entity == null) throw new Exception("Anarol ve rol bağlantısı bulunamadı");
        await _mainRoleAndRoleRelationshipService.RemoveByIdAsync(request.Id);
        return new();
    }
}
