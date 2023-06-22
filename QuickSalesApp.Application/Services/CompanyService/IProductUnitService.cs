using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.CreateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.UpdateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllByFilterProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllForProductList;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services;

public interface IProductUnitService
{
    Task CreateAsync(CreateProductUnitCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<ProductUnit>> GetAllActive(GetAllProductUnitQuery request);
    Task<ProductUnit> GetByIdAsync(int Id, string CompanyId);
    Task<ProductUnit> RemoveByIdHard(RemoveProductUnitCommand request);
    Task<ProductUnit> RemoveByIdSoft(string companyId, int id);
    Task<ProductUnit> ChangeState(ProductUnit productUnit, string companyId);
    Task<ProductUnit> UpdateAsync(UpdateProductUnitCommand request);
    int GetCount(string companyId);
    Task<GetByIdProductUnitQueryResponse> GetProductUnit(string companyId, int id);
    Task<PaginationResult<ProductUnit>> GetAllFilter(GetAllByFilterProductUnitQuery request);
    Task<PaginationResult<ProductUnit>> GetAllFilterForProduct(GetAllForProductListQuery request);
    int GetCountbyFilter(string companyId, string expression, string search);
}
