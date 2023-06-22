using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.StateCategory;

public sealed class StateCategoryCommandHandler : ICommandHandler<StateCategoryCommand, StateCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public StateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<StateCategoryCommandResponse> Handle(StateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryService.GetByIdAsync(request.CompanyId, request.CategoryId);
        if (category == null) throw new Exception("Bu Kategori Bulunamadı");

        category.IsActive = request.IsActive;
        category.UpdaterName = request.UpdaterName;
        category.UpdateDate = DateTime.Now;

        Category newDepartment = await _categoryService.ChangeState(request.CompanyId, category);
        return new();
    }
}
