using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.StateCategory;

public sealed record StateCategoryCommand(
    string CompanyId,
    int CategoryId,
    bool IsActive,
    string UpdaterName

    ) :ICommand<StateCategoryCommandResponse>;
