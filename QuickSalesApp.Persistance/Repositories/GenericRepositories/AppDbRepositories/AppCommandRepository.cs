using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Domain.Abstractions;
using QuickSalesApp.Domain.Repositories.GenericRepositories.AppDbContext;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Repositories.GenericRepositories.AppDbRepositories;

public  class AppCommandRepository<T> : IAppCommandRepository<T> where T : Entity
{
    private static readonly Func<AppDbContext, string, Task<T>> GetByIdCompiled =
            EF.CompileAsyncQuery((AppDbContext context, string id) =>
            context.Set<T>().FirstOrDefault(p => p.Id == id));

    private readonly AppDbContext _context;


    public AppCommandRepository(AppDbContext context)
    {
        _context = context;
        Entity = _context.Set<T>();
    }



    public DbSet<T> Entity { get; set; }


    
    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken )
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public void Remove(T entity)
    {
        Entity.Remove(entity);
    }

    public async Task RemoveById(string id)
    {
        T entity = await GetByIdCompiled(_context, id);
        Remove(entity);
    }


    public void RemoveRange(IEnumerable<T> entities)
    {
        Entity.RemoveRange(entities);
    }



    public void Update(T entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        Entity.UpdateRange(entities);
    }
}
