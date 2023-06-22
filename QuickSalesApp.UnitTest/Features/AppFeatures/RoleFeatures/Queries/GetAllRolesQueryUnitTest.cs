
using Moq;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Queryies.GetAllRoles;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;
using Shouldly;

namespace QuickSalesApp.UnitTest.Features.AppFeatures.RoleFeatures.Queries;

public sealed class GetAllRolesQueryUnitTest
{
    private readonly Mock<IRoleService> _roleService;

    public GetAllRolesQueryUnitTest()
    {
        _roleService = new();
    }


    [Fact]
    public async Task GetAllQueryResponseShouldNotBeNull()
    {
        _roleService.Setup(x => x.GetAllRolesAync())
        .ReturnsAsync(new List<AppRole>());
    }

}

