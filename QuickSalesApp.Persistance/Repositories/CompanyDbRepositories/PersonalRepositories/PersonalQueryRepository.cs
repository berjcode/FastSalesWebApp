using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.PersonalRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.PersonalRepositories
{
    public sealed class PersonalQueryRepository
        : CompanyDbQueryRepository<Personal>, IPersonalQueryRepository
    {

        
    }
}
