using QuickSalesApp.Domain.Abstractions;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.GenericRepositories.AppDbContext;

public interface IAppCommandRepository<T> :IAppRepository<T> where T : Entity
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    Task RemoveById(string id);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}

