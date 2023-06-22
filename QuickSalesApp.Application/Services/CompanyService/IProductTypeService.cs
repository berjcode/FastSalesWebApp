using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.CreateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.UpdateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetAllProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface IProductTypeService
{
    Task CreateAsync(CreateProductTypeCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<ProductType>> GetAllActive(GetAllProductTypeQuery request);
    Task<ProductType> GetByIdAsync(int id, string companyId);
    Task<ProductType> GetByNameAsync(string Name, string companyId);
    Task<ProductType> RemoveByIdHard(RemoveProductTypeCommand request);
    Task<ProductType> RemoveByIdSoft(string companyId, ProductType type);
    Task<ProductType> ChangeState(ProductType productType, string companyId);
    Task<ProductType> UpdateAsync(UpdateProductTypeCommand request);
    int GetCount(string companyId);
    Task<GetByIdProductTypeQueryResponse> GetProductType(string companyId, int id);
    Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id);
}
