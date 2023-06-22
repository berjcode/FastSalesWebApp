using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.VatTypeRepositories
{
    public interface IVatTypeQueryRepository
        : ICompanyDbQueryRepository<VatType>
    {
    }
}
