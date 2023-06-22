using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveUnit;

public sealed record RemoveUnitCommand(
    int id,
    string CompanyId
    ) : ICommand<RemoveUnitCommandResponse>;