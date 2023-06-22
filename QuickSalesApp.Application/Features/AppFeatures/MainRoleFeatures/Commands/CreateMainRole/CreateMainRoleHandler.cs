
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed class CreateMainRoleHandler : ICommandHandler<CreateMainRoleCommand, CreateMainRoleResponse>
{
    private readonly IMainRoleService _mainRoleService;
    public CreateMainRoleHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<CreateMainRoleResponse> Handle(CreateMainRoleCommand request, CancellationToken cancellationToken)
    {

        MainRole checkMainRoleTitle = await _mainRoleService.GetByTitleAndCompanyId(request.Title, request.CompanyId,cancellationToken);
        if (checkMainRoleTitle != null) throw new Exception("Bu Rol Daha Önce Oluşturulmuştur.");


        MainRole mainRole = new(
            Guid.NewGuid().ToString(),
            request.Title,
          request.CompanyId != null ? false : true ,
            request.CompanyId);

        await _mainRoleService.CreateAsync(mainRole, cancellationToken);

        return new();
    }
}
