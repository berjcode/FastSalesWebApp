using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.MainRoleRepositories;

public sealed class MainRoleQueryRepository : AppQueryRepository<MainRole>, IMainRoleQueryRepository
{
    public MainRoleQueryRepository(AppDbContext context) : base(context)
    {
    }
}
