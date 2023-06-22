using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllByFilterProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByIdProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetProductLastCode;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService
{
    public  interface IProductService
    {
        Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken);
        Task<Product> GetByCodeAsync(string code, string companyId);
        Task<PaginationResult<Product>> GetAllActive(string companyId, int pageNumber, int pageSize);
        Task<Product> GetByNameAsync(string name, string companyId);
        Task<Product> GetByIdAsync(int id, string companyId);
        Task<Product> RemoveByIdHard(int id, string companyId);
        Task<Product> RemoveByIdSoft(string companyId, Product product);
        Task<Product> ChangeState(Product product, string companyId);
        Task<Product> UpdateAsync(UpdateProductCommand request);
        int GetCount(string companyId);
        Task<GetByIdProductQueryResponse> GetProduct(string companyId, int id);
        Task<PaginationResult<Product>> GetAllFilter(GetAllByFilterProductQuery request);
        int GetCountbyFilter(string companyId, string expression);
        string GetLastCode(GetProductLastCodeQuery request);
    }
}
