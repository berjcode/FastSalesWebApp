using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateAllMainRoles;

public sealed record CreateAllMainRolesCommand(List<MainRole> MainRoles) : ICommand<CreateAllMainRolesResponse>;


