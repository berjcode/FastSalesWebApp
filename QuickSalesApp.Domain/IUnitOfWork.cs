using Microsoft.EntityFrameworkCore;

namespace QuickSalesApp.Domain;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken =default);
  

}
