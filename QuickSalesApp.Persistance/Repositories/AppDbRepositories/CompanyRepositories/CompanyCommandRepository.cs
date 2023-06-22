using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.CompanyRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.CompanyRepositories;

public sealed class CompanyCommandRepository : AppCommandRepository<Company>, ICompanyDbQueryRepository
{
    public CompanyCommandRepository(AppDbContext context) : base(context)
    {
    }
}
