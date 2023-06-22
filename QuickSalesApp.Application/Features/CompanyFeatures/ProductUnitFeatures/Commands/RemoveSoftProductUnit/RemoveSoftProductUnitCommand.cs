using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveSoftProductUnit;

public sealed record RemoveSoftProductUnitCommand(
        int Id,
        string CompanyId
    ) : ICommand<RemoveSoftProductUnitCommandResponse>;

