using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.UpdateProductType;

public sealed record UpdateProductTypeCommand(
        int Id,
        string Name,
        string UpdaterName,
        string CompanyId
    ) : ICommand<UpdateProductTypeCommandResponse>;