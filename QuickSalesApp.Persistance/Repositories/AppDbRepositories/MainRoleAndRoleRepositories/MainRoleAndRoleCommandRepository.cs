using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndRoleRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleAndRoleRepositories;

public sealed class MainRoleAndRoleCommandRepository : AppCommandRepository<MainRoleAndRoleRelationShip>, IMainRoleAndRoleComandRepository
{
    public MainRoleAndRoleCommandRepository(AppDbContext context) : base(context)
    {
    }
}
