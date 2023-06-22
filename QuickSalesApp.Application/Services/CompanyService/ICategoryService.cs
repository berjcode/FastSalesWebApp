
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.UpdateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ICategoryService
{
    Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
    Task<Category> GetByNameAsync(string companyId, string name);
    Task<GetCategoryQueryResponse> GetCategory(string companyId, int id);
    Task<Category> GetByIdAsync(string companyId, int id);
    Task<Category> RemoveByIdHard(string companyId, int id);
    Task<Category> RemoveByIdSoft(string companyId, Category category);
    Task<Category> UpdateAsync(UpdateCategoryCommand request);
    Task<PaginationResult<Category>> GetAllActive(string companyId,int pageNumber,int pageSize);
    Task<Category> ChangeState(string companyId, Category category);
    int GetCount(string companyId);
    int GetProductCountByCategoryId(string companyId, int categoryId);
    Task<PaginationResult<Category>> GetWithUnactive(string companyId, int pageNumber, int pageSize);
    Task<PaginationResult<Category>> GetAllFilter(GetAllFilterCategoryQuery request);
    int GetCountbyFilter(string companyId, string expression);
    Task<IList<Category>> GetAllJustCategory(string  companyId);
    Task<IList<Category>> GetAllProductByCategory(string companyId, int id);
    Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id);
}
