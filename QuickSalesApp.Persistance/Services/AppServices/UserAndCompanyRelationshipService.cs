using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.UserAndCompanyRepositories;

namespace QuickSalesApp.Persistance.Services.AppServices;

public sealed class UserAndCompanyRelationshipService : IUserAndCompanyRelationshipService
{
    private readonly IUserAndCompanyCommandRepository _compandRepository;
    private readonly IUserAndCompanyQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _appUnitOfWork;

    public UserAndCompanyRelationshipService(IUserAndCompanyCommandRepository compandRepository,
        IUserAndCompanyQueryRepository queryRepository, IAppUnitOfWork appUnitOfWork)
    {
        _compandRepository = compandRepository;
        _queryRepository = queryRepository;
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task Create(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken)
    {
        await _compandRepository.AddAsync(userAndCompanyRelationship, cancellationToken);
        await _appUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserAndCompanyRelationship> GetByIdAsync(string id)
    {
        return await _queryRepository.GetById(id); 
    }

    public async Task<UserAndCompanyRelationship> GetByUSerIdAndCompanyId(string userId, string companyId,CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.AppUserId == userId && p.CompanyId == companyId, cancellationToken);

    }

    public async Task<IList<UserAndCompanyRelationship>> GetListByUserId(string userId)
    {
        return await _queryRepository.GetWhere(p => p.AppUserId ==userId).Include("Company").ToListAsync();    
    }

    public async Task RemoveByIdAsync(string id)
    {
        await _compandRepository.RemoveById(id);
        await _appUnitOfWork.SaveChangesAsync();
    }
}
