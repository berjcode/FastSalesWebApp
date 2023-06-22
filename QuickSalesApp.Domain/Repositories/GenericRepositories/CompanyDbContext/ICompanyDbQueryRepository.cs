using QuickSalesApp.Domain.Abstractions;
using System.Linq.Expressions;

namespace QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyDbQueryRepository<T> : ICompanyDbRepository<T> where T : EntityBase
    {
      
        IQueryable<T> GetAll(bool isTracking = true);
        
        IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
        Task<T> GetById(int id, bool isTracking = true);
        Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, bool isTracking = true);
        Task<T> GetFirst(bool isTracking = true);

         int Count(Expression<Func<T, bool>> expression);
        Task<T> GetValidationData(Expression<Func<T, bool>> expression, bool isTracking = true);

    }
}
