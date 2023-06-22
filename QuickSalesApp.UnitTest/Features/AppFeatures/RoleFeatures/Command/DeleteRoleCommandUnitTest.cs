using Moq;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;
using Shouldly;

namespace QuickSalesApp.UnitTest.Features.AppFeatures.RoleFeatures.Command;
public sealed class DeleteRoleCommandUnitTest
{

    private readonly Mock<IRoleService> _roleServiceMock;
    public DeleteRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

    public async Task AppRoleShouldNotBeNull()
    {
        _roleServiceMock.Setup(

      x => x.GetById(It.IsAny<string>()))
      .ReturnsAsync(new AppRole());
    }

    [Fact]
    public async Task DeleteRoleCommandResponseShouldNotBeNull()
    {
        var command = new DeleteRoleCommand(Id: "asd");

        _roleServiceMock.Setup(
      x => x.GetById(It.IsAny<string>()))
      .ReturnsAsync(new AppRole());
        var handler = new DeleteRoleCommandHandler(_roleServiceMock.Object);
        DeleteRoleCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}

