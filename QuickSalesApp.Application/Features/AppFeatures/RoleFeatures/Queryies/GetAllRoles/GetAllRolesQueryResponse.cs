using QuickSalesApp.Domain.AppEntities.Identity;
namespace QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Queryies.GetAllRoles
{
    public sealed record GetAllRolesQueryResponse(
        IList<AppRole> Roles);

}
