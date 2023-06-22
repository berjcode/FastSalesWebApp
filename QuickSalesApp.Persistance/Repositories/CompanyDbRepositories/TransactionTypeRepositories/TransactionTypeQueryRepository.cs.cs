using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.TransactionTypeRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.TransactionTypeRepositories
{
    public sealed class TransactionTypeQueryRepository
        : CompanyDbQueryRepository<TransactionType>, ITransactionTypeQueryRepository
    {
    }
}
