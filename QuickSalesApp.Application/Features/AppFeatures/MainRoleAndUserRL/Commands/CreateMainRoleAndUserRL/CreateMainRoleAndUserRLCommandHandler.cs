

using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleAndUserRL.Commands.CreateMainRoleAndUserRL;

public sealed class CreateMainRoleAndUserRLCommandHandler : ICommandHandler<CreateMainRoleAndUserRLCommand, CreateMainRoleAndUserRLCommandResponse>
{
    private readonly IMainRoleAndUserRelationshipService _service;

    public CreateMainRoleAndUserRLCommandHandler(IMainRoleAndUserRelationshipService service)
    {
        _service = service;
    }

    public async Task<CreateMainRoleAndUserRLCommandResponse> Handle(CreateMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationship checkEntity = await _service.GetByUserIdCompanyIdAndMainRoleIdAsync(request.UserId,
            request.CompanyId, request.MainRoleId, cancellationToken);

        if (checkEntity != null) throw new Exception("Kullanıcı bu role zaten sahip");

        MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
            Guid.NewGuid().ToString(), request.UserId, request.MainRoleId, request.CompanyId);

        await _service.CreateAsync(mainRoleAndUserRelationship, cancellationToken);

        return new();
    }
}
