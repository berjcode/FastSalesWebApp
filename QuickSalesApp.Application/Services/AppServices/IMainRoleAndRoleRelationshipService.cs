using QuickSalesApp.Domain.AppEntities;

namespace QuickSalesApp.Application.Services.AppServices;
public interface IMainRoleAndRoleRelationshipService
{
    Task CreateAsync(MainRoleAndRoleRelationShip mainRoleAndRoleRelationShip, CancellationToken cancellationToken);
    Task UpdateAsync(MainRoleAndRoleRelationShip mainRoleAndRoleRelationShip);
    Task RemoveByIdAsync(string id);
    Task<MainRoleAndRoleRelationShip> GetByIdAsync(string id);
    Task<IList<MainRoleAndRoleRelationShip>> GetByMainRoleIdForGetRolesAsync(string id);
    IQueryable<MainRoleAndRoleRelationShip> GetAll();
    Task<MainRoleAndRoleRelationShip> GetByRoleIdAndMainRoleId(string roleId, string mainRoleId, CancellationToken cancellationToken);

}
