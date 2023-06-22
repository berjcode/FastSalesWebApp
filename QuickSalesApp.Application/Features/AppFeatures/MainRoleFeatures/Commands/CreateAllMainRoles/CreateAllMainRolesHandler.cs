
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Roles;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateAllMainRoles;

public sealed class CreateAllMainRolesHandler : ICommandHandler<CreateAllMainRolesCommand, CreateAllMainRolesResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public CreateAllMainRolesHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<CreateAllMainRolesResponse> Handle(CreateAllMainRolesCommand request, CancellationToken cancellationToken)
    {

        List<MainRole> mainRoles = RoleList.GetStaticMainRoles();
        List<MainRole> newMainRoles = new List<MainRole>();

        foreach (var mainRole in mainRoles)
        {
            MainRole checkMainRole = await  _mainRoleService.GetByTitleAndCompanyId(mainRole.Title, mainRole.CompanyId,cancellationToken);
            if (checkMainRole == null)  newMainRoles.Add(mainRole);
        }

        await _mainRoleService.CreateRangeAsync(newMainRoles,cancellationToken);

        return new();
    }
}
