
using Moq;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;
using Shouldly;

namespace QuickSalesApp.UnitTest.Features.AppFeatures.RoleFeatures.Command;

public sealed class CreateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleService;

    public CreateRoleCommandUnitTest()
    {
        _roleService = new();
    }

    [Fact]
    public  async Task AppRoleShouldBeNull()
    {
        AppRole appRole = await _roleService.Object.GetByCode("Product.Get");
        appRole.ShouldBeNull();
    }

    [Fact]
    public async Task CreateRoleCommandResponseShouldtNotBeNull()
    {
        var command = new CreateRoleCommand(
            Code:"Product.Get",
            Name: "Kayıt getirme");

        var handler = new CreateRoleCommandHandler(_roleService.Object);
        CreateRoleCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
    }
}

