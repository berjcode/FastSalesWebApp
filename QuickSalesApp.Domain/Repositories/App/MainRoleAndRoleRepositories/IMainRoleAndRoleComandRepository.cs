using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.AppDbContext;

namespace QuickSalesApp.Domain.Repositories.App.MainRoleAndRoleRepositories;

public interface IMainRoleAndRoleComandRepository : IAppCommandRepository<MainRoleAndRoleRelationShip>
{
}
