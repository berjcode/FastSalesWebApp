using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.SafeRepositories
{
    public interface ISafeQueryRepository
        : ICompanyDbQueryRepository<Safe>
    {
    }
}
