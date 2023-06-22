using QuickSalesApp.Domain.AppEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.AppDbContext;

namespace QuickSalesApp.Domain.Repositories.App.UserAndCompanyRepositories;

public interface IUserAndCompanyCommandRepository  :IAppCommandRepository<UserAndCompanyRelationship>
{
}
