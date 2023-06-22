using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveSoftProductType;

public sealed record RemoveSoftProductTypeCommand(
        int id,
        string CompanyId,
        bool IsDelete,
        string DeleterName
    ) : ICommand<RemoveSoftProductTypeCommandResponse>;