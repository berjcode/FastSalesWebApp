using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductTransactionRepositories
{
    public sealed class ProductTransactionCommandRepository
        : CompanyDbCommandRepository<ProductTransaction>, IProductTransactionCommandRepository
    {
    }
}
