
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;
using QuickSalesApp.Domain.Roles;

namespace QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRole;

public sealed class CreateAllRolesCommandHandler : ICommandHandler<CreateAllRolesCommand, CreateAllRolesCommandResponse>
{
    private readonly IRoleService _roleService;

    public CreateAllRolesCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<CreateAllRolesCommandResponse> Handle(CreateAllRolesCommand request,
        CancellationToken cancellationToken)
    {

        IList<AppRole> orginalRolesList = RoleList.GetStaticRoles();
        IList<AppRole> currentRoleList = new List<AppRole>();
        foreach (var role in orginalRolesList)
        {
            AppRole checkRole = await _roleService.GetByCode(role.Code);
            if (checkRole == null) currentRoleList.Add(role);

           
        }
        await _roleService.AddRangeAsync(currentRoleList);
        return new();


    }
}


