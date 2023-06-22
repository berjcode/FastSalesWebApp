using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.RemoveCategory;

public sealed class RemoveCategoryCommandHandler : ICommandHandler<RemoveCategoryCommand, RemoveCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public RemoveCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        Category checkEntity = await _categoryService.GetByIdAsync(request.CompanyId, request.id);
        if (checkEntity == null) throw new Exception("Category Bulunamadı");
        await _categoryService.RemoveByIdHard(request.CompanyId, request.id);

        return new();
    }
}
