

using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleAndUserRL.Commands.CreateMainRoleAndUserRL;

public sealed record CreateMainRoleAndUserRLCommand(
    string UserId,
    string MainRoleId,
    string CompanyId)
    : ICommand<CreateMainRoleAndUserRLCommandResponse>;


