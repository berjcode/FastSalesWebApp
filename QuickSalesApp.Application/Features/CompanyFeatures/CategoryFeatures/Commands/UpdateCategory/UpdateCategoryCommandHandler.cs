using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryService.GetByIdAsync(request.CompanyId, request.Id);
        if (category == null) throw new Exception("bu category bulunamadı");

        Category category2 = await _categoryService.GetByNameAsync(request.CompanyId, request.Name);
        if (category2 != null && category2.IsActive == true && category2.Id != request.Id && category2.Name == request.Name) throw new Exception("Bu kategori adı zaten kayıtlı");
        


        await _categoryService.UpdateAsync(request);
        return new();
    }
}
