using QuickSalesApp.Application.Messaging;
namespace QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed record DeleteRoleCommand(
        string Id) : ICommand<DeleteRoleCommandResponse>;
}
