using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndRoleRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleAndRoleRepositories;

public sealed class MainRoleAndRoleQueryRepository : AppQueryRepository<MainRoleAndRoleRelationShip>, IMainRoleAndRoleQueryRepositories
{
    public MainRoleAndRoleQueryRepository(AppDbContext context) : base(context)
    {
    }
}
