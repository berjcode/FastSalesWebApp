using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.UnitRepositories
{
    public interface IUnitCommandRepository
        : ICompanyDbCommandRepository<Unit>
    {
    }
}
