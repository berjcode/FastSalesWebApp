using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using QuickSalesApp.Domain.AppEntities.Identity;

namespace QuickSalesApp.Application.Services.AppServices;

public interface IRoleService
{
    Task AddAsync(CreateRoleCommand request);
    Task AddRangeAsync(IEnumerable<AppRole> roles);
    Task UpdateAsync(AppRole appRole);
    Task DeleteAsync(AppRole appRole);
    Task<IList<AppRole>> GetAllRolesAync();
    Task<AppRole> GetById(string id);
    Task<AppRole> GetByCode(string code);



}

