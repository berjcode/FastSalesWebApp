using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.DeleteCategory;

public sealed  record DeleteCategoryCommand(
    string CompanyId,
    int CategoryId,
    bool IsDelete,
    string DeleterName
    ) :ICommand<DeleteCategoryCommandResponse>;


