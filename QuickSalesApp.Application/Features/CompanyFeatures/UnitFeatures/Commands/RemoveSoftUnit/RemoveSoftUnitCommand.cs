using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveSoftUnit;

public sealed record RemoveSoftUnitCommand(
        string CompanyId,
        int UnitId,
        bool IsDelete,
        string DeleterName
    ) : ICommand<RemoveSoftUnitCommandResponse>;