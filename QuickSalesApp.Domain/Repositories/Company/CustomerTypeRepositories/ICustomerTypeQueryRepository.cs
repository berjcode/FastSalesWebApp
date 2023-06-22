using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.CustomerTypeRepositories;

public  interface ICustomerTypeQueryRepository: ICompanyDbQueryRepository<CustomerType>
{
}
