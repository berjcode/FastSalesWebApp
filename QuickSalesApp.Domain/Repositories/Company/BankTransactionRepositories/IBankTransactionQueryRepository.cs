using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.BankTransactionRepositories;
public interface IBankTransactionQueryRepository : ICompanyDbQueryRepository<BankTransaction>
{
}
