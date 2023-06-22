using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.PersonalRepositories
{
    public interface IPersonalQueryRepository : ICompanyDbQueryRepository<Personal>
    {
        
    }
}
