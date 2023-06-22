using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndRoleRepositories;

namespace QuickSalesApp.Persistance.Services.AppServices;

public class MainRoleAndRoleRelationshipService : IMainRoleAndRoleRelationshipService
{

    private readonly IMainRoleAndRoleComandRepository _mainRoleAndRoleComandRepository;
    private readonly IMainRoleAndRoleQueryRepositories _mainRoleAndRoleQueryRepositories;
    private readonly IAppUnitOfWork _appUnitOfWork;

    public MainRoleAndRoleRelationshipService(IMainRoleAndRoleComandRepository mainRoleAndRoleComandRepository,
        IMainRoleAndRoleQueryRepositories mainRoleAndRoleQueryRepositories, IAppUnitOfWork appUnitOfWork)
    {
        _mainRoleAndRoleComandRepository = mainRoleAndRoleComandRepository;
        _mainRoleAndRoleQueryRepositories = mainRoleAndRoleQueryRepositories;
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task CreateAsync(MainRoleAndRoleRelationShip mainRoleAndRoleRelationShip, CancellationToken cancellationToken)
    {
        await _mainRoleAndRoleComandRepository.AddAsync(mainRoleAndRoleRelationShip, cancellationToken);
        await _appUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRoleAndRoleRelationShip> GetAll()
    {
        return _mainRoleAndRoleQueryRepositories.GetAll();
    }

    public async Task<MainRoleAndRoleRelationShip> GetByIdAsync(string id)
    {
        return await _mainRoleAndRoleQueryRepositories.GetById(id);
    }

    public async Task<IList<MainRoleAndRoleRelationShip>> GetByMainRoleIdForGetRolesAsync(string id)
    {
      return await _mainRoleAndRoleQueryRepositories.GetWhere(p=> p.MainRoleId == id).Include("AppRole").ToListAsync();
    }

    public async Task<MainRoleAndRoleRelationShip> GetByRoleIdAndMainRoleId(string roleId, string mainRoleId, CancellationToken cancellationToken =default)
    {
        return await _mainRoleAndRoleQueryRepositories.GetFirstByExpression(p => p.RoleId == roleId && p.MainRoleId == mainRoleId, cancellationToken);
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _mainRoleAndRoleComandRepository.RemoveById(id);
        await _appUnitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(MainRoleAndRoleRelationShip mainRoleAndRoleRelationShip)
    {
        _mainRoleAndRoleComandRepository.Update(mainRoleAndRoleRelationShip);
        await _appUnitOfWork.SaveChangesAsync();
    }
}
