using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.TransactionTypeRepositories
{
    public interface ITransactionTypeQueryRepository
        : ICompanyDbQueryRepository<TransactionType>
    {
    }
}
