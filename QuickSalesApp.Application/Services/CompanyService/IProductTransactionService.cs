using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.CreateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.UpdateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetAllProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services;

public interface IProductTransactionService
{
    Task CreateAsync(CreateProductTransactionCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<ProductTransaction>> GetAllActive(GetAllProductTransactionQuery request);
    Task<ProductTransaction> GetByIdAsync(int id, string companyId);
    Task<ProductTransaction> RemoveByIdHard(RemoveProductTransactionCommand request);
    Task<ProductTransaction> RemoveByIdSoft(string companyId, ProductTransaction transaction);
    Task<ProductTransaction> ChangeState(ProductTransaction productTransaction, string companyId);
    Task<ProductTransaction> UpdateAsync(UpdateProductTransactionCommand request);
    int GetCount(string companyId);
    Task<GetByIdProductTransactionQueryResponse> GetProductTransaction(string companyId, int id);
}
