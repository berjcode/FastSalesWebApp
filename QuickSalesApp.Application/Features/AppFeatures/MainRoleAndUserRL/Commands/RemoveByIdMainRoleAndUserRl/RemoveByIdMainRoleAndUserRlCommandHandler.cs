

using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleAndUserRL.Commands.RemoveByIdMainRoleAndUserRl;

public sealed class RemoveByIdMainRoleAndUserRlCommandHandler : ICommandHandler<RemoveByIdMainRoleAndUserRLCommand, RemoveByIdMainRoleAndUserRlCommandResponse>
{

    private readonly IMainRoleAndUserRelationshipService _service;

    public RemoveByIdMainRoleAndUserRlCommandHandler(IMainRoleAndUserRelationshipService service)
    {
        _service = service;
    }

    public async Task<RemoveByIdMainRoleAndUserRlCommandResponse> Handle(RemoveByIdMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationship checkEntity = await _service.GetByIdAsync(request.Id, false);
        if (checkEntity == null) throw new Exception("Kullanıcı bu role zaten sahip  değil");



        await _service.RemoveByIdAsync(request.Id);

        return new();
    }

}
