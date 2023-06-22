
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.CompanyRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.CompanyRepositories;

public sealed class CompanyQueryRepository : AppQueryRepository<Company>, ICompanyQueryRepository
{
    public CompanyQueryRepository(AppDbContext context) : base(context)
    {
    }
}
