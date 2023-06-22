using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.CustomerRepositories;

public interface ICustomerCommandRepository : ICompanyDbCommandRepository<Customer>
{
}
