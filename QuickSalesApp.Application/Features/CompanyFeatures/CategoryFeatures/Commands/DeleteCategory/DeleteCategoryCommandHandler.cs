using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.DeleteCategory;

public sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
{
    private readonly ICategoryService _service;

    public DeleteCategoryCommandHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _service.GetByIdAsync(request.CompanyId, request.CategoryId);
        if (category == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        var check = await _service.GetByIdForCheck(request.CompanyId, request.CategoryId);
        if (check.ProductName != null) throw new Exception(ExceptionMessage.CategoryNotDeleteException);

        category.IsDelete = request.IsDelete;
        category.DeleterName = request.DeleterName;
        category.DeletedTime = DateTime.Now;
        category.IsActive = false;

        Category newCategory = await _service.RemoveByIdSoft(request.CompanyId, category);
        return new();
    }
}
