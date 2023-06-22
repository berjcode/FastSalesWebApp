using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndUserRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleAndUserRepositories;

public sealed class MainRoleAndUserCommandRepository : AppCommandRepository<MainRoleAndUserRelationship>, IMainRoleAndUserCommandRepository
{
    public MainRoleAndUserCommandRepository(AppDbContext context) : base(context)
    {
    }
}
