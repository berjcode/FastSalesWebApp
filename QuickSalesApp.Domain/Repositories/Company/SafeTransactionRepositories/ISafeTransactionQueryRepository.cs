using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.SafeTransactionRepositories
{
    public interface ISafeTransactionQueryRepository
        : ICompanyDbQueryRepository<SafeTransaction>
    {
    }
}
