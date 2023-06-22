
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;

public sealed record class RemoveMainRoleCommand(string Id ) :ICommand<RemoveMainRoleCommandResponse>; 
