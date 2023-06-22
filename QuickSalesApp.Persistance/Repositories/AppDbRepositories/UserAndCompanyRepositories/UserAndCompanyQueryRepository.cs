using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.App.UserAndCompanyRepositories;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.AppDbRepositories.UserAndCompanyRepositories;

public sealed class UserAndCompanyQueryRepository : AppQueryRepository<UserAndCompanyRelationship>, IUserAndCompanyQueryRepository
{
    public UserAndCompanyQueryRepository(AppDbContext context) : base(context)
    {
    }
}
