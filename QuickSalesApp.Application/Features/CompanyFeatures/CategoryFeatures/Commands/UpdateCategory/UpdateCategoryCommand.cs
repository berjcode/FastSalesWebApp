using Microsoft.EntityFrameworkCore.Storage;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand(

    string CompanyId,
    int Id,
    string Name,
    string Description,
    string UpdaterName): ICommand<UpdateCategoryCommandResponse>;

