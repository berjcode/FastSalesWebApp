using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;

namespace QuickSalesApp.Persistance.Services.AppServices
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task AddAsync(CreateRoleCommand request)
        {
            AppRole role = _mapper.Map<AppRole>(request);
            role.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);
        }
        public async Task AddRangeAsync(IEnumerable<AppRole> roles)
        {
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }

        }

        public async Task DeleteAsync(AppRole appRole)
        {

            await _roleManager.DeleteAsync(appRole);
        }

        public async Task<IList<AppRole>> GetAllRolesAync()
        {
            IList<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return roles;

        }

        public async Task<AppRole> GetByCode(string code)
        {
            AppRole role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Code == code);
            return role;
        }

        public async Task<AppRole> GetById(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task UpdateAsync(AppRole appRole)
        {
            await _roleManager.UpdateAsync(appRole);
        }


    }
}
