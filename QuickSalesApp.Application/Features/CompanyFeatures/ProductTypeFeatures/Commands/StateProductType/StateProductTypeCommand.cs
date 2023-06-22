using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.StateProductType;

public sealed record StateProductTypeCommand(
        int Id,
        string CompanyId,
        bool IsActive,
        string DeleterName
    ) : ICommand<StateProductTypeCommandResponse>;
