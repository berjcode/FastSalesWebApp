using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.AppDbContext;

namespace QuickSalesApp.Domain.Repositories.App.MainRoleAndUserRepositories;

public interface IMainRoleAndUserQueryRepository : IAppQueryRepository<MainRoleAndUserRelationship>
{
}
