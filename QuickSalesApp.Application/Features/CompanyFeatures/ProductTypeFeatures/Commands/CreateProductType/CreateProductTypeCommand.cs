using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.CreateProductType;

public sealed record CreateProductTypeCommand(
        string Name,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateProductTypeCommandResponse>;
