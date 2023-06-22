using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.ProductTypeRepositories
{
    public interface IProductTypeQueryRepository
        : ICompanyDbQueryRepository<ProductType>
    {
    }
}
