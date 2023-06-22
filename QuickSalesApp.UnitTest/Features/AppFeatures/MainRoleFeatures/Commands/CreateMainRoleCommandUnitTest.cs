

using Moq;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;
using Shouldly;

namespace QuickSalesApp.UnitTest.Features.AppFeatures.MainRoleFeatures.Commands;

public sealed class CreateMainRoleCommandUnitTest
{

    private readonly Mock<IMainRoleService> _roleServiceMock;

    public CreateMainRoleCommandUnitTest()
    {
        _roleServiceMock = new();
    }

   

}
