using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.SafeRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.SafeRepositories
{
    public sealed class SafeCommandRepository
        : CompanyDbCommandRepository<Safe>, ISafeCommandRepository
    {
    }
}
