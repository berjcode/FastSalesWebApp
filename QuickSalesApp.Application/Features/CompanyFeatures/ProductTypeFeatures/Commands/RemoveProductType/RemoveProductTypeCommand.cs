using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveProductType;

public sealed record RemoveProductTypeCommand(
    int id,
    string CompanyId) : ICommand<RemoveProductTypeCommandResponse>;