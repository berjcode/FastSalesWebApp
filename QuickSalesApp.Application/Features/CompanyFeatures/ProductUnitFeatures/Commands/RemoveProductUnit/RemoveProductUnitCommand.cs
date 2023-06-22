using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveProductUnit;

public sealed record RemoveProductUnitCommand(
        int Id,
        string CompanyId
    ) : ICommand<RemoveProductUnitCommandResponse>;

