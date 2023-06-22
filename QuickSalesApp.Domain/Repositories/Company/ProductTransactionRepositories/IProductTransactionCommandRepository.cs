using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.ProductTransactionRepositories
{
    public interface IProductTransactionCommandRepository
        : ICompanyDbCommandRepository<ProductTransaction>
    {
    }
}
