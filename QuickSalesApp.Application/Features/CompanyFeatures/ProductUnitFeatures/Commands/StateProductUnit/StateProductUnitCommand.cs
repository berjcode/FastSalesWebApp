using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.StateProductUnit;

public sealed record StateProductUnitCommand(
        string CompanyId,
        int Id,
        bool IsDefault,
        string DeleterName
    ) : ICommand<StateProductUnitCommandResponse>;