using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.CustomerTransactionRepositories;

public interface ICustomerTransactionQueryRepository: ICompanyDbQueryRepository<CustomerTransaction>
{
}
