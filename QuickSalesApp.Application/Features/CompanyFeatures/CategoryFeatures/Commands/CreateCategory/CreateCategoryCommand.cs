using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;

public sealed record CreateCategoryCommand (
    string Name,
    string CreatorName,
    string Description,
    string CompanyId

  ) : ICommand<CreateCategoryCommandResponse>;

