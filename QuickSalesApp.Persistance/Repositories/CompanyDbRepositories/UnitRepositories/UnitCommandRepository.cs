using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.UnitRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.UnitRepositories
{
    public sealed class UnitCommandRepository
        : CompanyDbCommandRepository<Unit>, IUnitCommandRepository
    {
    }
}
