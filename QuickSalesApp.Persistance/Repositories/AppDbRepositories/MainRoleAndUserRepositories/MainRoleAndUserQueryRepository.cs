using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndUserRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleAndUserRepositories;

public sealed class MainRoleAndUserQueryRepository : AppQueryRepository<MainRoleAndUserRelationship>, IMainRoleAndUserQueryRepository
{
    public MainRoleAndUserQueryRepository(AppDbContext context) : base(context)
    {
    }
}
