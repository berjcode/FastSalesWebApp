using Moq;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;
using Shouldly;

namespace QuickSalesApp.UnitTest.Features.AppFeatures.RoleFeatures.Command;

public sealed class UpdateRoleCommandUnitTestcs
{
    private readonly Mock<IRoleService> _roleService;

    public UpdateRoleCommandUnitTestcs()
    {
        _roleService = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _roleService.Setup(x => x.GetById(It.IsAny<string>()))
             .ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task AppRoleCodeShouldBeUniqe()
    {
        AppRole checkRoleCode = await _roleService.Object.GetByCode("Product.Get");
        checkRoleCode.ShouldBeNull();
    }
    [Fact]
    public async Task UpdateRoleCommandResponseShouldNotBeNull()
    {
        var command = new UpdateRoleCommand(
            Id: "ffbb810f-3df9-4273-ba17-e3ecc98ff78c"
            , Code: "Product.Get"
            , Name: "Product");
        _roleService.Setup(x => x.GetById(It.IsAny<string>()))
             .ReturnsAsync(new AppRole());
        var handler = new UpdateRoleCommandHandler(_roleService.Object);
        UpdateRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }
}

