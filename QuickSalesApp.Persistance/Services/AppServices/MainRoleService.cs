
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleRepositories;

namespace QuickSalesApp.Persistance.Services.AppServices;

public class MainRoleService : IMainRoleService
{

    private readonly IMainRoleCommadRepository _mainRoleCommadRepository;
    private readonly IMainRoleQueryRepository _mainRoleQueryRepository;
    private IAppUnitOfWork _appUnitOfWork;

    public MainRoleService(IMainRoleCommadRepository mainRoleCommadRepository, IMainRoleQueryRepository mainRoleQueryRepository, IAppUnitOfWork appUnitOfWork)
    {
        _mainRoleCommadRepository = mainRoleCommadRepository;
        _mainRoleQueryRepository = mainRoleQueryRepository;
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken)
    {
        await _mainRoleCommadRepository.AddAsync(mainRole,cancellationToken);
        await _appUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateRangeAsync(List<MainRole> newMainRoles, CancellationToken cancellationToken)
    {
        await _mainRoleCommadRepository.AddRangeAsync(newMainRoles,cancellationToken);

        await _appUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRole> GetAll()
    {
        return _mainRoleQueryRepository.GetAll();
    }

    public async Task<MainRole> GetByIdAsync(string id)
    {
        return await _mainRoleQueryRepository.GetById(id);
    }

    public async Task<MainRole> GetByTitleAndCompanyId(string title, string companyId,CancellationToken cancellationToken)
    {
       //if(companyId == null) return await _mainRoleQueryRepository.GetFirstByExpression(p => p.Title == title,false);

       return await _mainRoleQueryRepository.GetFirstByExpression(p =>p.Title == title && p.CompanyId == companyId,cancellationToken,false);
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _mainRoleCommadRepository.RemoveById(id);
        await _appUnitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(MainRole mainRole)
    {
        _mainRoleCommadRepository.Update(mainRole);
        await _appUnitOfWork.SaveChangesAsync();
    }
}
