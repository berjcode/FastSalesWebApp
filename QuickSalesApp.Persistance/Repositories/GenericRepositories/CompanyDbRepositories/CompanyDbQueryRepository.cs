using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Domain.Abstractions;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;
using QuickSalesApp.Persistance.Context;
using System.Linq.Expressions;

namespace QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

public class CompanyDbQueryRepository<T> : ICompanyDbQueryRepository<T> where T : EntityBase
{
    private static readonly Func<CompanyDbContext, int, bool, Task<T>> GetByIdCompiled =
       EF.CompileAsyncQuery((CompanyDbContext context, int id, bool isTracking) =>
   isTracking == true ? context.Set<T>().FirstOrDefault(p => p.Id == id) :
        context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));



    private static readonly Func<CompanyDbContext, bool, Task<T>> GetFirstCompiled =
       EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
       isTracking == true ? context.Set<T>().FirstOrDefault()
       : context.Set<T>().AsNoTracking().FirstOrDefault());


    private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, bool, Task<T>> GetFirstByExpressionCompiled =
     EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression, bool isTracking) =>
     isTracking == true ? context.Set<T>().FirstOrDefault(expression)
     : context.Set<T>().AsNoTracking().FirstOrDefault(expression));

    private CompanyDbContext _context;
    public DbSet<T> Entity { get; set; }


    public void SetDbContextInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
        Entity = _context.Set<T>();
    }

    public IQueryable<T> GetAll(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
            result = result.AsNoTracking();
        return result;
    }

    public async Task<T> GetById(int id, bool isTracking = true)
    {
        //return await GetByIdCompiled(_context, id, isTracking);
        return await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<T> GetFirst(bool isTracking = true)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, bool isTracking = true)
    {
        T entity = null;
        if (!isTracking)
            entity = await Entity.AsNoTracking().Where(expression).FirstOrDefaultAsync();
        else
            entity = await Entity.Where(expression).FirstOrDefaultAsync();

        return entity;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var result = Entity.Where(expression);
        if (!isTracking)
            result = result.AsNoTracking();
        return result;
    }

    public Task<T> GetValidationData(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var query = Entity.AsQueryable();
        if (!isTracking)
        {
            query = query.AsNoTracking();

        }
        var result = query.FirstOrDefault(expression);
        return Task.FromResult(result);
    }

    public int Count(Expression<Func<T, bool>> expression)
    {
      return Entity.Count(expression);
    }
}