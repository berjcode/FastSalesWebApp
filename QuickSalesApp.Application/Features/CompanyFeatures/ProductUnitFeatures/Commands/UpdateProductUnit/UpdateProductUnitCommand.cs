using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.UpdateProductUnit;

public sealed record UpdateProductUnitCommand(
        int Id,
        decimal Factor,
        bool IsDefault,
        int UnitId,
        bool IsVat,
        decimal Price,
        int ProductId,
        string UpdaterName,
        string CompanyId,
        decimal Amount
    ) : ICommand<UpdateProductUnitCommandResponse>;
