using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.UserAndCompanyRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.UserAndCompanyRepositories;

public sealed class UserAndCompanyCommandRepository : AppCommandRepository<UserAndCompanyRelationship>, IUserAndCompanyCommandRepository
{
    public UserAndCompanyCommandRepository(AppDbContext context) : base(context)
    {
    }
}
