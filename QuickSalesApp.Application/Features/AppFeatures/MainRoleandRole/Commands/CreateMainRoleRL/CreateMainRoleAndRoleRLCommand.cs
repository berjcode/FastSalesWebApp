using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRoleRL;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRole;

public sealed record CreateMainRoleAndRoleRLCommand(
    string RoleId,
    string MainRoleId): ICommand<CreateMainRoleAndRoleRLCommandResponse>;
