using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductUnitRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductUnitRepositories
{
    public sealed class ProductUnitQueryRepository
        : CompanyDbQueryRepository<ProductUnit>, IProductUnitQueryRepository
    {
    }
}
