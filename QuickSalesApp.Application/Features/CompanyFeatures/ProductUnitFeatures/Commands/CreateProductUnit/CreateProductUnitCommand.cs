using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.CreateProductUnit;

public sealed record CreateProductUnitCommand(
        int ProductId,
        decimal Factor,
        decimal Price,
        bool IsDefault,
        int UnitId,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateProductUnitCommandResponse>;