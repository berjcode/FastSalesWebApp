using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.MainRoleAndUserRepositories;

namespace QuickSalesApp.Persistance.Services.AppServices;

public sealed class MainRoleAndUserRelationshipService : IMainRoleAndUserRelationshipService
{

    private readonly IMainRoleAndUserCommandRepository _commandRepository;
    private readonly IMainRoleAndUserQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleAndUserRelationshipService(IMainRoleAndUserCommandRepository commandRepository,
        IMainRoleAndUserQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRoleAndUserRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<MainRoleAndUserRelationship> GetByIdAsync(string id, bool isTracking)
    {
        return await _queryRepository.GetById(id, false);
    }

    public async Task<MainRoleAndUserRelationship> GetByUserIdCompanyIdAndMainRoleIdAsync(string userId, string companyId, string mainRoleId, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.UserId == userId && p.CompanyId == companyId && p.MainRoleId == mainRoleId, cancellationToken);
    }

    public async Task<MainRoleAndUserRelationship> GetRolesByUserIdAndCompanyId(string userId, string companyId)
    {
        return await _queryRepository.GetFirstByExpression(p => p.UserId == userId && p.CompanyId == companyId, default);

    }

    public async Task RemoveByIdAsync(string id)
    {
        await _commandRepository.RemoveById(id);
    }
}
