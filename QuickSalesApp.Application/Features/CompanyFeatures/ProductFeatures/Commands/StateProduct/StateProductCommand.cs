using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.StateProduct;


public sealed record StateProductCommand(
        string CompanyId,
        int Id,
        bool IsActive,
        string DeleterName
    ) : ICommand<StateProductCommandResponse>;
