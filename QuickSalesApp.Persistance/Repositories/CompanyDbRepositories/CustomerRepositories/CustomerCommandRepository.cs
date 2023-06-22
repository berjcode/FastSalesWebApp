using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CustomerRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CustomerRepositories;

public sealed class CustomerCommandRepository : CompanyDbCommandRepository<Customer>, ICustomerCommandRepository
{
}
