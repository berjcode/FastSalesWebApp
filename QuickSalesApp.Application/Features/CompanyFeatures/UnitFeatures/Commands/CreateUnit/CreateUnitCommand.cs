using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.CreateUnit;

public sealed record CreateUnitCommand(
        string Name,
        decimal Factor,
        bool IsDat,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateUnitCommandResponse>;
