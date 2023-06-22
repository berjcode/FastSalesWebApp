

using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

public sealed record CreateMainRoleCommand(string Title,
  
    string CompanyId = null):  ICommand<CreateMainRoleResponse>;

