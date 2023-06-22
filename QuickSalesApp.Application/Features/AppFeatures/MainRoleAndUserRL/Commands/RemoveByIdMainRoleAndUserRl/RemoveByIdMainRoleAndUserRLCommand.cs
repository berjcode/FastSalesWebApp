
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleAndUserRL.Commands.RemoveByIdMainRoleAndUserRl;

public sealed record RemoveByIdMainRoleAndUserRLCommand(
    string Id) : ICommand<RemoveByIdMainRoleAndUserRlCommandResponse>;
