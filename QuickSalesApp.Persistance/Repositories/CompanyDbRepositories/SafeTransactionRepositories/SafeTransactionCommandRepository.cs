using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.SafeTransactionRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.SafeTransactionRepositories
{
    public sealed class SafeTransactionCommandRepository
        : CompanyDbCommandRepository<SafeTransaction>, ISafeTransactionCommandRepository
    {
    }
}
