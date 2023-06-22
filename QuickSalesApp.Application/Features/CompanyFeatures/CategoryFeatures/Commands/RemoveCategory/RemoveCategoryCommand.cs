using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.RemoveCategory;

public sealed record RemoveCategoryCommand(
    int id,
    string CompanyId) : ICommand<RemoveCategoryCommandResponse>;
