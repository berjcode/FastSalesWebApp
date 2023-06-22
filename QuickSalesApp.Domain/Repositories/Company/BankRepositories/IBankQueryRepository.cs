using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.BankRepositories;

public interface IBankQueryRepository : ICompanyDbQueryRepository<Bank>
{
}
