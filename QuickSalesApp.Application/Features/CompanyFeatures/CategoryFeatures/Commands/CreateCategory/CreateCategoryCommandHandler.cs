using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        Category category = await _categoryService.GetByNameAsync(request.CompanyId, request.Name);
        if (category != null) throw new Exception("Bu Kategori Daha önce kayıt edilmiş");

        await _categoryService.CreateAsync(request, cancellationToken);

        return new();
    }
}
