using QuickSalesApp.Domain.AppEntities;
using System.Threading;

namespace QuickSalesApp.Application.Services.AppServices;

public interface IUserAndCompanyRelationshipService
{
    Task Create(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken);
    Task RemoveByIdAsync(string id);
    Task<UserAndCompanyRelationship> GetByIdAsync(string id);
    Task<UserAndCompanyRelationship> GetByUSerIdAndCompanyId(string userId, string companyId, CancellationToken cancellationToken);
    Task<IList<UserAndCompanyRelationship>> GetListByUserId(string userId);

}
