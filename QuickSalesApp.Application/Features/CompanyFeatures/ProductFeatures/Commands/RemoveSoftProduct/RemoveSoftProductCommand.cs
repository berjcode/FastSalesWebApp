using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveSoftProduct;

public sealed record RemoveSoftProductCommand(
        int id,
        string CompanyId,
        bool IsDelete,
        string DeleterName
    ) : ICommand<RemoveSoftProductCommandResponse>;
