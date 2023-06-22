using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.CurrencyRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.CurrencyRepositories;

public sealed class CurrencyCommandRepository :CompanyDbCommandRepository<Currency>, ICurrencyCommandRepository
{
}
