using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Queryies.GetAllRoles
{
    public sealed record GetAllRolesQuery() : IQuery<GetAllRolesQueryResponse>;
}
