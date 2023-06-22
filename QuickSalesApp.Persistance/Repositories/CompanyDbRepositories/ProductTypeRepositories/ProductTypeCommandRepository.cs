using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductTypeRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductTypeRepositories
{
    public sealed class ProductTypeCommandRepository
        : CompanyDbCommandRepository<ProductType>, IProductTypeCommandRepository
    {
    }
}
