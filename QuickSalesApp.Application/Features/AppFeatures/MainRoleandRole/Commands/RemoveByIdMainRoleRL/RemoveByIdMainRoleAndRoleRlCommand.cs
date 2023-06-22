using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveByIdMainRoleRL;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveMainRoleRL;

public sealed record RemoveByIdMainRoleAndRoleRlCommand(string Id) : ICommand<RemoveByIdMainRoleAndRoleRlCommandResponse>;

