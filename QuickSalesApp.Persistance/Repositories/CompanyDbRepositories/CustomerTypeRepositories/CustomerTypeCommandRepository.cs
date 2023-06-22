

using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CustomerTypeRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CustomerTypeRepositories;

public sealed class CustomerTypeCommandRepository :CompanyDbCommandRepository<CustomerType>, ICustomerTypeCommandRepository
{
}
