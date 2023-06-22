using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.StateUnit;

public sealed record StateUnitCommand(
        int Id,
        string CompanyId,
        bool IsActive,
        string DeleterName
    ) : ICommand<StateUnitCommandResponse>;
