 using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRole;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRoleRL;

public sealed class CreateMainRoleAndRoleRLCommandHandler : ICommandHandler<CreateMainRoleAndRoleRLCommand, CreateMainRoleAndRoleRLCommandResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _mainRoleAndRoleRelationshipService;

    public CreateMainRoleAndRoleRLCommandHandler(IMainRoleAndRoleRelationshipService mainRoleAndRoleRelationshipService)
    {
        _mainRoleAndRoleRelationshipService = mainRoleAndRoleRelationshipService;
    }

    public async Task<CreateMainRoleAndRoleRLCommandResponse> Handle(CreateMainRoleAndRoleRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationShip checkRoleAndMainRoleIsRelated =
            await _mainRoleAndRoleRelationshipService.GetByRoleIdAndMainRoleId(request.RoleId, request.MainRoleId,cancellationToken);
        if (checkRoleAndMainRoleIsRelated != null) throw new Exception("Bu rol  ilişkisi daha önce kurulmuştur.");

        MainRoleAndRoleRelationShip mainRoleAndRoleRelationShip = new(
            Guid.NewGuid().ToString(),
            request.RoleId,
            request.MainRoleId
            );

        await _mainRoleAndRoleRelationshipService.CreateAsync(mainRoleAndRoleRelationShip, cancellationToken);
        return new();
    }
}
