using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveProduct;

public sealed record RemoveProductCommand(
        int Id,
        string CompanyId
    ) : ICommand<RemoveProductCommandResponse>;
